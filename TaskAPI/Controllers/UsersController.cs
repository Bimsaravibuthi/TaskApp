using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Services.Users;
using TaskAPI.Services.Models;

namespace TaskAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _service;

        public UsersController(IUserRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _service.GetAllUsers();
            var usersDto = new List<UserDto>();

            foreach(var user in users)
            {
                usersDto.Add(new UserDto
                {
                    USR_ID = user.USR_ID,
                    USR_NIC = user.USR_NIC,
                    USR_NAMEFULL = $"{user.USR_NAMEFULL}, {user.USR_LEVEL}"
                });
            }

            if(usersDto is null)
            {
                return NotFound();
            }

            return Ok(usersDto);
        }

        [HttpGet("{userLevel}")]
        public IActionResult FilterAndSearchUsers(string userLevel)
        {
            var users = _service.FilterAndSearchUsers(userLevel);
            var usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                usersDto.Add(new UserDto
                {
                    USR_ID = user.USR_ID,
                    USR_NIC = user.USR_NIC,
                    USR_NAMEFULL = $"{user.USR_NAMEFULL}, {user.USR_LEVEL}"
                });
            }

            if (usersDto is null)
            {
                return NotFound();
            }

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _service.GetUser(id);

            if(user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
