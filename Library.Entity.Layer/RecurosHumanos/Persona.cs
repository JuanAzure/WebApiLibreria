using System;
using System.Collections.Generic;

namespace Library.EntityLayer
{
    public partial class Persona
    {
        public Persona()
        {
            Ingreso = new HashSet<Ingreso>();
            Venta = new HashSet<Venta>();
        }

        public int Idpersona { get; set; }
        public string TipoPersona { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Ingreso> Ingreso { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
