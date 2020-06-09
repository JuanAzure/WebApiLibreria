using System;
using System.Collections.Generic;

namespace Library.EntityLayer
{
    public partial class Ingreso
    {
        public Ingreso()
        {
            DetalleIngreso = new HashSet<DetalleIngreso>();
        }

        public int Idingreso { get; set; }
        public int Idproveedor { get; set; }
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
        public virtual ICollection<DetalleIngreso> DetalleIngreso { get; set; }
    }
}
