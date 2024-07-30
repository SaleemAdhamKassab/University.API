namespace University.API.DTOs
{
	public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }
}
