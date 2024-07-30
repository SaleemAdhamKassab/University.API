using Microsoft.AspNetCore.Mvc;
using University.API.DTOs;
using University.API.Services.Auth;

namespace University.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController(IAuthService authService) : BaseController
	{
		private readonly IAuthService _authService = authService;

		[HttpPost("register")]
		public async Task<IActionResult> register(RegisterDto registerDto) => _returnResultWithMessage(await _authService.register(registerDto));

		[HttpPost("login")]
		public async Task<IActionResult> login(LoginDto loginDto) => _returnResultWithMessage(await _authService.login(loginDto));
	}
}