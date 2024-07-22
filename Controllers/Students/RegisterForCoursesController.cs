using Microsoft.AspNetCore.Mvc;
using static University.API.Portals.Students.RegisterForCourses.RegisterForCoursesService;

namespace University.API.Controllers.Students
{
    [Route("api/students/[controller]")]
    [ApiController]
    public class RegisterForCoursesController : BaseController
    {
        private readonly IRegisterForCourses _registerForCourses;
        public RegisterForCoursesController(IRegisterForCourses registerForCourses)
        {
            _registerForCourses = registerForCourses;
        }

        [HttpGet("getStudentCourses/{studentId}")]
        public async Task<IActionResult> getStudentCourses(int studentId) => _returnResultWithMessage(_registerForCourses.getStudentCoursesAsync(studentId));

        [HttpGet("GetItems")]
        public async Task<IActionResult> GetItems([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string sort, [FromQuery] string order)
        {
            return Ok();
        }
    }
}
