using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto request)
        {
            var newUser = new User(request.Email, request.Password, "salt", request.Username, request.DateOfBirth);
            
            return Created($"users/{request.Email}", null);
        }
    }
}