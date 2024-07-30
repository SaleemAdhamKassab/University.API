using System.ComponentModel.DataAnnotations;

namespace University.API.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Phone { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string PasswordHash { get; set; }
        public DateTime AddedOn { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
	}
}
