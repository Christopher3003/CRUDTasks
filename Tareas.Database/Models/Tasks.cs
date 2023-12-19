using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Database.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Description { get; set; }
        public DateTime Fecha { get; set; }
    }
}
