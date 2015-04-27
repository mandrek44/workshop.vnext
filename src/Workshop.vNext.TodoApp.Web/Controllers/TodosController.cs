using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using Workshop.vNext.TodoApp.Web.Models;

namespace Workshop.vNext.TodoApp.Web.Controllers
{
    [Route("Todos")]
    public class TodosController
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
            return _todos.OrderBy(b => b.Task).ToList();
        }

        [HttpGet("{id}")]
        public Todo Get(int id)
        {
            return _todos.SingleOrDefault(t => t.Id == id);
        }

        [HttpPost("")]
        public void Post([FromBody]Todo todo)
        {
            _todos.Add(todo);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toDelete = _todos.FirstOrDefault(t => t.Id == id);
            if (toDelete != null)
            {
               _todos.Remove(toDelete);
            }
        }
    }
}
