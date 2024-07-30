using static University.API.Helper.ServiceResult;
using University.API.Models;
using University.API.DTOs;

namespace University.API.Services.Students
{
	public interface IStudentsService
	{
		ResultWithMessage getStudentCoursesAsync(int studentId);
		ResultWithMessage registerForCourses(StudentCoursesDto studentCoursesDto);
	}

	public class StudentsService(ApplicationDbContext db) : IStudentsService
	{
		private readonly ApplicationDbContext _db = db;

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

		public ResultWithMessage registerForCourses(StudentCoursesDto studentCoursesDto)
		{
			if (studentCoursesDto.StudentId == 0 || studentCoursesDto.CoursesIds.Count == 0)
				return new ResultWithMessage(null, "Invalid model");

			foreach (int courseId in studentCoursesDto.CoursesIds)
			{
				_db.StudentCourses.Add(new Models.StudentCourse
				{
					StudentId = studentCoursesDto.StudentId,
					CourseId = courseId,
					Date = DateTime.Now
				});
			}
			_db.SaveChanges();

			return new ResultWithMessage(null, string.Empty);
		}
	}
}