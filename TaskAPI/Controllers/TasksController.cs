using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Services.Taasks;

namespace TaskAPI.Controllers
{
    [Route("api/users/{userId}/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaasksRepository _service;

        public TasksController(ITaasksRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTasks(string userId)
        {
            var task = _service.GetAllTasks(userId);

            if(task is null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(string userId, string id)
        {
            var task = _service.GetTask(userId, id);
            
            if(task is null)
            {
                return NotFound();
            }

            return Ok(task);
        }
    }
}
