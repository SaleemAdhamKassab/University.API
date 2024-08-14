using System.ComponentModel.DataAnnotations;

namespace University.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string UserType { get; set; }
        public DateTime AddedOn { get; set; }
        public List<Student> Students { get; set; }
        public List<Employee> Employees { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}