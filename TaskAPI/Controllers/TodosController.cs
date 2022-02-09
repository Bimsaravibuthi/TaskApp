using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Models;
using TaskAPI.Services;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private TodoService _todoService;

        public TodosController()
        {
            _todoService = new TodoService();
        }
        
        [HttpGet("{id?}")]
        public IActionResult GetTodos(int? id)
        {
            var myTodos = _todoService.AllTodos();

            if (id is null) return Ok(myTodos);

            myTodos = myTodos.Where(t => t.Id == id).ToList();

            return Ok(myTodos);
        }

        //[HttpGet]   //Select
        //public IActionResult Tasks()
        //{
        //    var Tasks = new string[] { "Task 1", "Task 2", "Task 3","Task 4","Task 5" };
        //    return Ok(Tasks);
        //}

        //[HttpPost]  //Insert
        //public IActionResult NewTask()
        //{
        //    return Ok();
        //}

        //[HttpPut]   //Update
        //public IActionResult UpdateTask()
        //{
        //    return Ok();
        //}

        //[HttpDelete]    //Delete
        //public IActionResult DeleteTask()
        //{
        //    return Ok();
        //}
    }
}
