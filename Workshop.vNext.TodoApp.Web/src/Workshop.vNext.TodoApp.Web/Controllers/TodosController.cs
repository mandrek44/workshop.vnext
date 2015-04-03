using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.vNext.TodoApp.Web.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Workshop.vNext.TodoApp.Web.Controllers
{
    [Route("Todos")]
    public class TodosController : Controller
    {
		private static List<Todo> _todos = new List<Todo>();
		
		static TodosController()
		{
			_todos.Add(new Todo { Id = 1, Task = "Take garbage" });
            _todos.Add(new Todo { Id = 2, Task = "Drive home" });
            _todos.Add(new Todo { Id = 3, Task = "Find Wally" });
		}
		

        [HttpGet("")]
        public ICollection<Todo> Get()
        {
           return _todos;
        }


        [HttpPost("")]
        public void Post([FromBody]Todo todo)
        {
           _todos.Add(todo);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			// TODO...
        }
    }
}
