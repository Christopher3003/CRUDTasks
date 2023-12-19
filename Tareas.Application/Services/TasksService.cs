using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Application.Repositories;
using Tareas.Application.ViewModels;
using Tareas.Database.Context;
using Tareas.Database.Models;

namespace Tareas.Application.Services
{
    public class TasksService
    {
        private readonly TasksRepository _tasksRepository;
        public TasksService(ApplicationContext context)
        {
            _tasksRepository = new TasksRepository(context);
        }

        public async Task<TasksSaveViewModel> GetById(int id)
        {
            var task = await _tasksRepository.GetByIdAsync(id);
            TasksSaveViewModel vm = new TasksSaveViewModel();
            vm.Id = task.Id;
            vm.Nombre = task.Nombre;
            vm.Description = task.Description;
            vm.Fecha = task.Fecha;
            return vm;
        }

        public async Task create(TasksSaveViewModel vm)
        {
            Tasks task = new();
            task.Id = vm.Id;
            task.Nombre = vm.Nombre;
            task.Description = vm.Description;
            task.Fecha = vm.Fecha;

            await _tasksRepository.AddAsync(task);
        }

        public async Task update(TasksSaveViewModel vm)
        {
            Tasks task = new();
            task.Id = vm.Id;
            task.Nombre = vm.Nombre;
            task.Description = vm.Description;
            task.Fecha = vm.Fecha;
            await _tasksRepository.UpdateAsync(task);
        }

        public async Task<List<TasksViewModel>> ReadAll()
        {
            var tasks = await _tasksRepository.GetAllAsync();
            return tasks.Select(t => new TasksViewModel
            {
                Nombre = t.Nombre,
                Description = t.Description,
                Id = t.Id,
                Fecha = t.Fecha,
            }).ToList();
        }

        public async Task Delete(int id)
        {
            var task = await _tasksRepository.GetByIdAsync(id);
            await _tasksRepository.DeleteAsync(task);
        }
    }
}
