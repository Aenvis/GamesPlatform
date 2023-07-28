using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesPlatform.Infrastructure.Commands.UsersLibraries
{
	public class AddUserGameNodeCommand : ICommand
	{
		public Guid UserId { get; set; }
		public Guid GameId { get; set; }
	}
}
