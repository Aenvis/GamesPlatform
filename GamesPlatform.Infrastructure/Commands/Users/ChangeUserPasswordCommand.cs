namespace GamesPlatform.Infrastructure.Commands.Users
{
	public class ChangeUserPasswordCommand : ICommand
	{
		public string Email { get; set; }
		public string OldPassword { get; set; }
		public string NewPassword { get; set; }
	}
}
