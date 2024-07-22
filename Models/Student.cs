using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace University.API.Models
{
	public class Student
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string Password { get; set; }

		public List<StudentCourse> StudentCourses { get; set; }
	}
}