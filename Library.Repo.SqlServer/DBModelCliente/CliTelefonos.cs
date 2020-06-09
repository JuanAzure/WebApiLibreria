using System;
using System.Collections.Generic;

namespace Library.Repo.SqlServer.DBModelCliente
{
    public partial class CliTelefonos
    {
        public int Id { get; set; }
        public int? Idcliente { get; set; }
        public string Telefono { get; set; }

        public virtual Clientes IdclienteNavigation { get; set; }
    }
}
