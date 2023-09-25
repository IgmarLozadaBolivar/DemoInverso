using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Departamento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdPaisFk { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    public virtual Pai IdPaisFkNavigation { get; set; } = null!;
}
