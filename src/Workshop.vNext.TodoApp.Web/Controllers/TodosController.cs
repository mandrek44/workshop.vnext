using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.vNext.TodoApp.Web.Infrastructure;
using Workshop.vNext.TodoApp.Web.Models;

namespace Workshop.vNext.TodoApp.Web.Controllers
{
    [Route("Todos")]
    public class TodosController
    {
        static TodosController()
        {
            using (var ctx = new TodosContext())
            {
                ctx.Todos.Add(new Todo { Id = 1, Task = "Take garbage" });
                ctx.Todos.Add(new Todo { Id = 2, Task = "Drive home" });
                ctx.Todos.Add(new Todo { Id = 3, Task = "Find Wally" });

                ctx.SaveChanges();
            }
        }

		[HttpGet("")]
		public async Task<ICollection<Todo>> Get()
		{
			using (var ctx = new TodosContext())
			{
				return await ctx.Todos.OrderBy(b => b.Task).ToListAsync();
			}
		}

		[HttpGet("{id}")]
		public async Task<Todo> Get(int id)
		{
			return null;
			using (var ctx = new TodosContext())
			{
				return await ctx.Todos.SingleOrDefaultAsync(t => t.Id == id);
			}
		}

		[HttpPost("")]
		public async Task Post([FromBody]Todo todo)
		{
			using (var ctx = new TodosContext())
			{
				ctx.Todos.Add(todo);
				await ctx.SaveChangesAsync();
			}
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			using (var ctx = new TodosContext())
			{
				var toDelete = await ctx.Todos.FirstOrDefaultAsync(t => t.Id == id);
				if (toDelete != null)
				{
					ctx.Todos.Remove(toDelete);
					await ctx.SaveChangesAsync();
				}
			}
		}
	}
}
