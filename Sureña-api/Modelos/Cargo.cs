using System;
using System.Collections.Generic;

namespace Sureña_api.Modelos;

public partial class Cargo
{
    public string Nombre { get; set; } = null!;

    public string Supervisor { get; set; } = null!;

    public string ObjetivoCargo { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<Funcione> Funciones { get; } = new List<Funcione>();

    public virtual ICollection<Relacione> RelacioneIdCargoNavigations { get; } = new List<Relacione>();

    public virtual ICollection<Relacione> RelacioneIdCargoRelacionNavigations { get; } = new List<Relacione>();
}
