using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Pattern.EF.EFCore;
using System.Collections.Generic;

namespace Repository.Pattern.EF.Entities
{
    public partial class Categoria:IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Condicion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
