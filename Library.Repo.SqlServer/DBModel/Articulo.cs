using System;
using System.Collections.Generic;

namespace Library.Repo.SqlServer.DBModel
{
    public partial class Articulo
    {
        public Articulo()
        {
            DetalleIngreso = new HashSet<DetalleIngreso>();
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Idarticulo { get; set; }
        public int Idcategoria { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public bool? Condicion { get; set; }

        public virtual Categoria IdcategoriaNavigation { get; set; }
        public virtual ICollection<DetalleIngreso> DetalleIngreso { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
