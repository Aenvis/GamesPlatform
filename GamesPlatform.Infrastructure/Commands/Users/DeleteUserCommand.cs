using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesPlatform.Infrastructure.Commands.Users
{
	public class DeleteUserCommand : ICommand
	{
		public string Email { get; set; }
	}
}
