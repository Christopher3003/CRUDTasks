using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Application.ViewModels
{
    public class TasksSaveViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Description { get; set; }
        public DateTime Fecha { get; set; }
    }
}
