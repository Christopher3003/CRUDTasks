using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Database.Models;

namespace Tareas.Database.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }

        public DbSet<Tasks> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Tasks>().ToTable("Tareas");
            model.Entity<Tasks>().HasKey(t=>t.Id);
            model.Entity<Tasks>()
                .Property(t => t.Nombre)
                .IsRequired();
            model.Entity<Tasks>()
                .Property(t =>t.Description)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
