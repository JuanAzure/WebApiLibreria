using System;
using System.Collections.Generic;

namespace Library.EntityLayer
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Idventa { get; set; }
        public int Idcliente { get; set; }
        public int Idusuario { get; set; }
        public string TipoComprobante { get; set; }
        public string SerieComprobante { get; set; }
        public string NumComprobante { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
