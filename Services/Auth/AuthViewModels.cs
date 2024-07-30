namespace University.API.Services.Auth
{
	public class AuthModel
	{
		public string Email { get; set; }
		public string Message { get; set; }
		public string Token { get; set; }
		public bool IsAuthenticated { get; set; }
		public DateTime ExpiresOn { get; set; }
		public List<string> Errors { get; set; }
		public List<string> Roles { get; set; }
	}
}
