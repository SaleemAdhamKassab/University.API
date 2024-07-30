using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.API.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		public string EmployeeSpecificField { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }
		public User User { get; set; }
	}
}
