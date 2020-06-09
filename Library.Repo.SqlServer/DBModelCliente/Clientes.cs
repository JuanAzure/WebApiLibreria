using System;
using System.Collections.Generic;

namespace Library.Repo.SqlServer.DBModelCliente
{
    public partial class Clientes
    {
        public Clientes()
        {
            CliDirecciones = new HashSet<CliDirecciones>();
            CliTelefonos = new HashSet<CliTelefonos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? Fechadenacimiento { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<CliDirecciones> CliDirecciones { get; set; }
        public virtual ICollection<CliTelefonos> CliTelefonos { get; set; }
    }
}
