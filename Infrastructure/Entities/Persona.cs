using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Persona
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public int IdCiuFk { get; set; }

    public int Edad { get; set; }

    public int IdTipoDoc { get; set; }

    public virtual Ciudad IdCiuFkNavigation { get; set; } = null!;

    public virtual TipoDocumento IdTipoDocNavigation { get; set; } = null!;
}
