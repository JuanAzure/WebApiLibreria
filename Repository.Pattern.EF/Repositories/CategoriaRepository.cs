
using Repository.Pattern.EF.EFCore;
using Repository.Pattern.EF.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Repository.Pattern.EF.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {


        public CategoriaRepository(DBLibraryContext dbcontext) : base(dbcontext)
        {

        }

        public List<Categoria> Search(string keyword)
        {
            return GetAll().Where(i => i.Nombre.Contains(keyword.Trim().ToLower())).ToList();
                           //.Where(i => i.Descripcion.Contains(keyword.Trim().ToLower())).ToList();
        }

        //public List<Articulo> Search(decimal min, decimal max)
        //{
        //    return  GetAll().Where(i=>i.PrecioVenta >= min && i.PrecioVenta<= max).ToList();
        //}

    }
}
