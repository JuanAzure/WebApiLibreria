using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apis.Models
{
    public class MCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }


        public string FechaDeNacimiento { get; set; }
        public IEnumerable<MCliDirecciones> Direcciones { get; set; }
        public IEnumerable<MCliTelefonos> Telefonos { get; set; }

    }
}
