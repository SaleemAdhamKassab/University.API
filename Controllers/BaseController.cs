using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static University.API.Helper.ServiceResult;

namespace University.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController : ControllerBase
	{
		protected IActionResult _returnResultWithMessage(ResultWithMessage result)
		{
			if (string.IsNullOrEmpty(result.Message))
				return Ok(result.Data);

			else return BadRequest(new { message = result.Message });
		}
	}
}
