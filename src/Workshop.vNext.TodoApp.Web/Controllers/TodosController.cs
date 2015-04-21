using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.InMemory;
using Workshop.vNext.TodoApp.Web.Infrastructure;
using Workshop.vNext.TodoApp.Web.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Workshop.vNext.TodoApp.Web.Controllers
{
    [Route("Todos")]
    public class TodosController : Controller
    {
        public TodosController()
        {
            // TODO: initialize properly
            using (var db = new MyContext())
            {
                if (db.Todos.Any())
                {
                    return;
                }

                db.Todos.Add(new Todo { Id = 1, Task = "Take garbage" });
                db.Todos.Add(new Todo { Id = 2, Task = "Drive home" });
                db.Todos.Add(new Todo { Id = 3, Task = "Find Wally" });

                db.SaveChanges();
            }
        }

        [HttpGet("")]
        public async Task<ICollection<Todo>> Get()
        {
            using (var db = new MyContext())
            {
                return await db.Todos.OrderBy(b => b.Task).ToListAsync();
            }
        }

        [HttpGet("{id}")]
        public async Task<Todo> Get(int id)
        {
            using (var db = new MyContext())
            {
                return await db.Todos.SingleOrDefaultAsync(t => t.Id == id);
            }
        }

        [HttpPost("")]
        public async Task Post([FromBody]Todo todo)
        {
            using (var db = new MyContext())
            {
                db.Todos.Add(todo);
                await db.SaveChangesAsync();
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            using (var db = new MyContext())
            {
                var toDelete = await db.Todos.FirstOrDefaultAsync(t => t.Id == id);
                if (toDelete != null)
                {
                    db.Todos.Remove(toDelete);
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
