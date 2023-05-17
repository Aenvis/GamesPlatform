using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesPlatform.Infrastructure.DTOs
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; } 
        public DateTime DateOfBirth { get; set; }
    }
}