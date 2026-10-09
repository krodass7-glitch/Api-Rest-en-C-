using System;
using System.Collections.Generic;

namespace Api_Rest_en_C_.Models;

public partial class Marca
{
    public int IdMarca { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
