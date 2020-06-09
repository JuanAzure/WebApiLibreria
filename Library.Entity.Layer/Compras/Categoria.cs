using System;
using System.Collections.Generic;

namespace Library.EntityLayer
{
    public partial class Categoria
    {
        public Categoria()
        {
            Articulo = new HashSet<Articulo>();
        }

        public int Idcategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Condicion { get; set; }

        public virtual ICollection<Articulo> Articulo { get; set; }
    }
}
