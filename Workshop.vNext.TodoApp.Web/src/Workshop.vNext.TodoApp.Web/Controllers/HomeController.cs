﻿using System;
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
}
