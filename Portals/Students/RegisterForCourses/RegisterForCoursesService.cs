using Microsoft.EntityFrameworkCore;
using University.API.Models;
using static University.API.Helper.ServiceResult;

namespace University.API.Portals.Students.RegisterForCourses
{
	public class RegisterForCoursesService
	{
		public interface IRegisterForCourses
		{
			ResultWithMessage getStudentCoursesAsync(int studentId);
		}

		public class RegisterForCourses : IRegisterForCourses
		{
			private readonly ApplicationDbContext _db;
			public RegisterForCourses(ApplicationDbContext db)
			{
				_db = db;
			}

			public ResultWithMessage getStudentCoursesAsync(int studentId)
			{
				// add condition accordingly..
				List<StudentCourse> studentCourses = _db.Courses.Select(e => new StudentCourse
				{
					CourseId = e.Id,
					CourseName = e.Name

				})
				.ToList();

				if (studentCourses.Count == 0)
					return new ResultWithMessage(null, $"No Courses Founded for Student Id: {studentId}");

				return new ResultWithMessage(studentCourses, string.Empty);
			}
		}
	}
}