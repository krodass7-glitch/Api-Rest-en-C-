using System;
using System.Collections.Generic;

namespace Api_Rest_en_C_.Models;

public partial class DetalleFactura
{
    public int IdDetalle { get; set; }

    public int? IdFactura { get; set; }

    public int? IdProductos { get; set; }

    public int? Cantidad { get; set; }

    public float? PrecioUnitario { get; set; }

    public float? Subtotal { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }

    public virtual Producto? IdProductosNavigation { get; set; }
}
