using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet]   //Select
        public IActionResult Tasks()
        {
            var Tasks = new string[] { "Task 1", "Task 2", "Task 3" };
            return Ok(Tasks);
        }

        [HttpPost]  //Insert
        public IActionResult NewTask()
        {
            return Ok();
        }

        [HttpPut]   //Update
        public IActionResult UpdateTask()
        {
            return Ok();
        }

        [HttpDelete]    //Delete
        public IActionResult DeleteTask()
        {
            return Ok();
        }
    }
}
