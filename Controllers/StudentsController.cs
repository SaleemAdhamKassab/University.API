using Microsoft.AspNetCore.Mvc;
using University.API.Dtos;
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

        [HttpGet("getPayments")]
        public async Task<IActionResult> getPayments(string email) => _returnResultWithMessage(_studentsService.getPayments(email));
    }
}
