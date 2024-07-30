using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.API.Models
{
	public class StudentCourse
	{
		[Key]
		public int Id { get; set; }
		public DateTime Date { get; set; }

		[ForeignKey("Student")]
		public int StudentId { get; set; }
		public Student Student { get; set; }

		[ForeignKey("Course")]
		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}
