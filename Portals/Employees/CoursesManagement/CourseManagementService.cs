using University.API.Models;

namespace University.API.Portals.Employees.CoursesManagement
{
	public class CourseManagementService
	{
		public interface ICourseManagement
		{

		}

		public class CourseManagement : ICourseManagement
		{
			private readonly ApplicationDbContext _db;

			public CourseManagement(ApplicationDbContext db)
			{
				_db = db;
			}
		}
	}
}
