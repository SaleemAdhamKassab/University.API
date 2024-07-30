using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace University.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		[Authorize(Roles = "Student")]
		[HttpGet("protected")]
		public IActionResult GetProtectedData()
		{
			return Ok(new { message = "This is a protected endpoint for students only!" });
		}
	}
}
