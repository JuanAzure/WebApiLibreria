using System;
using System.Collections.Generic;

namespace Library.Repo.SqlServer.DBModelCliente
{
    public partial class CliDirecciones
    {
        public int Id { get; set; }
        public int Idcliente { get; set; }
        public string Direccion { get; set; }

        public virtual Clientes IdclienteNavigation { get; set; }
    }
}
