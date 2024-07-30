﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.API.Models
{
	public class Student
	{
		[Key]
		public int Id { get; set; }
		public string StudentSpecificField { get; set; }


		[ForeignKey("User")]
		public int UserId { get; set; }
		public User User { get; set; }

		public List<StudentCourse> StudentCourses { get; set; }
	}
}