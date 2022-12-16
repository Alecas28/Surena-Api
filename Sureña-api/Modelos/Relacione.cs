using System;
using System.Collections.Generic;

namespace Sureña_api.Modelos;

public partial class Relacione
{
    public int Id { get; set; }

    public int IdCargo { get; set; }

    public int IdCargoRelacion { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual Cargo IdCargoRelacionNavigation { get; set; } = null!;
}
