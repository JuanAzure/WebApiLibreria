using Repository.Pattern.EF.Entities;
using Repository.Pattern.EF.EFCore;
using System.Collections.Generic;

namespace Repository.Pattern.EF.Repositories
{
    public interface IArticuloRepository: IGenericRepository<Articulo>
    {

        public  List<Articulo> Search(string keyword);

        public List<Articulo> Search(decimal min,decimal max);

    }
}
