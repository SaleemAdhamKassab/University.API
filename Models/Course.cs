﻿using System.ComponentModel.DataAnnotations;

namespace University.API.Models
{
	public class Course
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<StudentCourse> StudentCourses { get; set; }
	}
}
