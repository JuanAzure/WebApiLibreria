
using Repository.Pattern.EF.EFCore;
using Repository.Pattern.EF.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Repository.Pattern.EF.Repositories
{
    public class ArticuloRepository : GenericRepository<Articulo>, IArticuloRepository
    {


        public ArticuloRepository(DBLibraryContext dbcontext) : base(dbcontext)
        {

        }

        public List<Articulo> Search(string keyword)
        {
            return  GetAll().Where(i => i.Nombre.Contains(keyword.Trim())).ToList();
        }

        public List<Articulo> Search(decimal min, decimal max)
        {
            return  GetAll().Where(i=>i.PrecioVenta >= min && i.PrecioVenta<= max).ToList();
        }

    }
}
