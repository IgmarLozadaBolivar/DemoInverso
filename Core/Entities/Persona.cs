using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Persona : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateOnly FechaNac { get; set; }
        public int IdCiuFK { get; set; }
        public Ciudad Ciudad { get; set; }
        public int Edad { get; set; }
        public int IdTipoDoc { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
    }
}