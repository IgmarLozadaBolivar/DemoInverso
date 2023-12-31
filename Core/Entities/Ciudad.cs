using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Ciudad : BaseEntity
    {
        public string Nombre { get; set; }
        public int IdDepFK { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
}