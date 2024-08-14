using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using University.API.Dtos;
using University.API.Models;
using static University.API.Helper.ServiceResult;

namespace University.API.Services.Auth
{
    public interface IAuthService
    {
        Task<ResultWithMessage> register(RegisterDto registerDto);
        Task<ResultWithMessage> login(LoginDto loginDto);
    }
    public class AuthService(ApplicationDbContext db, IConfiguration configuration) : IAuthService
    {
        private readonly ApplicationDbContext _db = db;
        private readonly IConfiguration _configuration = configuration;

        public async Task<ResultWithMessage> register(RegisterDto registerDto)
        {
            if (registerDto.UserType != "student" && registerDto.UserType != "employee")
                return new ResultWithMessage(null, "Invalid user type. Please specify 'student' or 'employee'");

            // Create a new User
            User user = new()
            {
                FirstName = registerDto.FirstName,
                FatherName = registerDto.FatherName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Phone = registerDto.Phone,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                DateOfBirth = registerDto.DateOfBirth,
                Gender = registerDto.Gender,
                Address = registerDto.Address,
                Username = registerDto.Email, //algorith to generate unique username
                UserType = "student",
                AddedOn = DateTime.Now
            };

            _db.Users.Add(user);

            if (registerDto.UserType == "student")
            {
                Student student = new()
                {
                    User = user,
                    IsActive = false
                };
                _db.Students.Add(student);
                _db.SaveChanges();

                // Assign "Student" role
                Role studentRole = await _db.Roles.FirstOrDefaultAsync(r => r.Name == "Student");
                if (studentRole != null)
                {
                    UserRole userRole = new()
                    {
                        UserId = user.Id,
                        RoleId = studentRole.Id
                    };
                    _db.UserRoles.Add(userRole);
                }
            }
            else if (registerDto.UserType == "employee")
            {
                Employee employee = new()
                {
                    UserId = user.Id,
                    EmployeeSpecificField = "TestEmployeeSpecificField"
                };
                _db.Employees.Add(employee);

                // Assign "Employee" role
                Role employeeRole = await _db.Roles.FirstOrDefaultAsync(r => r.Name == "Employee");
                if (employeeRole != null)
                {
                    var userRole = new UserRole
                    {
                        UserId = user.Id,
                        RoleId = employeeRole.Id
                    };
                    _db.UserRoles.Add(userRole);
                }
            }

            _db.SaveChanges();

            return new ResultWithMessage(null, string.Empty);
        }
        public async Task<ResultWithMessage> login(LoginDto loginDto)
        {
            AuthModel authModel = new();

            User user = await _db.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Email);
            if (user is null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return new ResultWithMessage(null, "Invalid login attempt");

            var roles = await _db.UserRoles.Where(ur => ur.UserId == user.Id)
                                            .Select(ur => ur.Role.Name)
                                            .ToListAsync();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            var expirationMinutes = int.Parse(_configuration["Jwt:ExpirationMinutes"]);

            authModel.Email = user.Email;
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(token);
            authModel.ExpiresOn = DateTime.Now.AddMinutes(expirationMinutes);
            authModel.Roles = roles;

            return new ResultWithMessage(authModel, string.Empty);
        }
    }
}
