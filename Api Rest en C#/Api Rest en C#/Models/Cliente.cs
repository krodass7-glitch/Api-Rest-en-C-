using System;
using System.Collections.Generic;

namespace Api_Rest_en_C_.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nit { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
