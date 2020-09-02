using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        ITaskService taskService { get; set; }
        public HomeController(ITaskService taskService )
        {
            this.taskService = taskService;
        }

        public IActionResult Index()
        {
           var Tasks = this.taskService.GetAll();
            return View(Tasks);
        }

        public  IActionResult SignUp()
        {
            return View();
        }
    }
}
