using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tareas.Application.Services;
using Tareas.Database.Context;
using Tareas.Models;

namespace Tareas.Controllers
{
    public class HomeController : Controller
    {
        private readonly TasksService _service;

        public HomeController(ApplicationContext logger)
        {
            _service = new(logger);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.ReadAll());
        }

     
    }
}