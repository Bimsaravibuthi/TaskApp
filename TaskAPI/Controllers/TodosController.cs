using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Services.Todos;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoService;

        public TodosController(ITodoRepository repository)
        {
            _todoService = repository;
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            var todos = _todoService.GetAllTodos();
            
            if(todos is null)
            {
                return NotFound();
            }

            return Ok(todos);
        }
        
        [HttpGet("{id?}")]
        public IActionResult GetTodo(int id)
        {
            var Todo = _todoService.GetTodo(id);

            if (Todo is null)
            {
                return NotFound();
            }

            return Ok(Todo);
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
