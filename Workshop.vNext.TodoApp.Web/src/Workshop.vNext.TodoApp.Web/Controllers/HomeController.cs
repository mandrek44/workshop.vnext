using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;

namespace Workshop.vNext.TodoApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

	public class TodoController
	{
        
        [HttpGet]  
        [ActionName("Index")]      
        public IEnumerable<TodoTask> GetAll()
        {
            return new TodoTask[]
            {
                new TodoTask() { Name = "test" }
            };
		}

        public class TodoTask
        {
            public TodoTask()
            {
            }

            public string Name { get; internal set; }
        }
    }
}