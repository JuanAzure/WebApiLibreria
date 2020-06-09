using System;
using System.Collections.Generic;

namespace Library.EntityLayer
{
    public partial class Rol
    {
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Idrol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Condicion { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
