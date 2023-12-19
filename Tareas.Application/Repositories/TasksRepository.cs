using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Application.ViewModels;
using Tareas.Database.Context;
using Tareas.Database.Models;

namespace Tareas.Application.Repositories
{
    public class TasksRepository
    {
        private readonly ApplicationContext _context;
        public TasksRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tasks task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tasks>> GetAllAsync()
        {
            return await _context.Set<Tasks>().ToListAsync();

        }

        public async Task UpdateAsync(Tasks task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tasks task)
        {
            _context.Set<Tasks>().Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<Tasks> GetByIdAsync(int id)
        {
            return await _context.Set<Tasks>().FindAsync(id);
        }
    }
}
