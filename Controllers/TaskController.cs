using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tareas.Application.Services;
using Tareas.Application.ViewModels;
using Tareas.Database.Context;

namespace Tareas.WebApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly TasksService service;

        public TaskController(ApplicationContext context)
        {
            service = new TasksService(context);
        }
        // GET: TaskController
        public async Task<ActionResult> Index()
        {
            return View(await service.ReadAll());

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(TasksSaveViewModel vm)
        {
            await service.create(vm);
            return RedirectToRoute(new {controller = "Task", action = "Index"});
        }

        public async Task<ActionResult> Update(int id)
        {
            return View("Create", await service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Update(TasksSaveViewModel vm)
        {
            await service.update(vm);
            return RedirectToRoute(new {controller = "Task", action = "Index" });
        }

        public async Task<ActionResult> Delete(int id)
        {

            return View("Delete", await service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> DeletePost(int id)
        {
            await service.Delete(id);
            return RedirectToRoute(new { controller = "Task", action = "Index" });
        }

       
    }
}
