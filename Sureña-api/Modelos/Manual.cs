using System;
using System.Collections.Generic;

namespace Sureña_api.Modelos;

public partial class Manual
{
    public int Id { get; set; }

    public string EdicionMan { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string CodigoMan { get; set; } = null!;

    public string Revision { get; set; } = null!;

    public virtual ICollection<Funcione> Funciones { get; } = new List<Funcione>();
}
