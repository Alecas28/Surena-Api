using System;
using System.Collections.Generic;

namespace Sureña_api.Modelos;

public partial class Funcione
{
    public int Id { get; set; }

    public int IdCargo { get; set; }

    public int IdManual { get; set; }

    public int NroFuncion { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual Manual IdManualNavigation { get; set; } = null!;
}
