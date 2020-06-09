using System;
using System.Collections.Generic;

namespace Library.Repo.SqlServer.DBModel
{
    public partial class DetalleVenta
    {
        public int IddetalleVenta { get; set; }
        public int Idventa { get; set; }
        public int Idarticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }

        public virtual Articulo IdarticuloNavigation { get; set; }
        public virtual Venta IdventaNavigation { get; set; }
    }
}
