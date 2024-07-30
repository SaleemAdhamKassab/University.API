using Microsoft.AspNetCore.Mvc;
using University.API.DTOs;
using University.API.Services.Students;

namespace University.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController(IStudentsService studentsService) : BaseController
	{
		private readonly IStudentsService _studentsService = studentsService;


		[HttpGet("getStudentCourses/{studentId}")]
		public async Task<IActionResult> getStudentCourses(int studentId) => _returnResultWithMessage(_studentsService.getStudentCoursesAsync(studentId));

		[HttpPost("registerForCourses")]
		public async Task<IActionResult> registerForCourses(StudentCoursesDto studentCoursesDto) => _returnResultWithMessage(_studentsService.registerForCourses(studentCoursesDto));

		[HttpGet("GetItems")]
		public async Task<IActionResult> GetItems([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string sort, [FromQuery] string order)
		{
			throw new Exception();
		}
	}
}
