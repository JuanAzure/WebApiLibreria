using System;
using System.Collections.Generic;

namespace Library.Repo.SqlServer.DBModel
{
    public partial class Usuario
    {
        public Usuario()
        {
            Ingreso = new HashSet<Ingreso>();
            Venta = new HashSet<Venta>();
        }

        public int Idusuario { get; set; }
        public int Idrol { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool? Condicion { get; set; }

        public virtual Rol IdrolNavigation { get; set; }
        public virtual ICollection<Ingreso> Ingreso { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
