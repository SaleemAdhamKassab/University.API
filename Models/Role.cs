using System.ComponentModel.DataAnnotations;

namespace University.API.Models
{
	public class Role
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public ICollection<UserRole> UserRoles { get; set; }
	}
}
