using Repository.Pattern.EF.EFCore;

namespace Library.Data.EF.Entities
{
    public partial class Articulo : IEntity
    {
        public int Id { get; set; }
        public int Idcategoria { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public bool Condicion { get; set; }

        public virtual Categoria Categoria { get; set; }



    }
}
