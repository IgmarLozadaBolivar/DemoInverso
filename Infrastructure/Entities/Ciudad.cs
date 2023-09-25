using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Ciudad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdDepFk { get; set; }

    public virtual Departamento IdDepFkNavigation { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
