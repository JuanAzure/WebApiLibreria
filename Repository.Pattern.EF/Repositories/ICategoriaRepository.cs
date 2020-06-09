using Repository.Pattern.EF.Entities;
using Repository.Pattern.EF.EFCore;
using System.Collections.Generic;

namespace Repository.Pattern.EF.Repositories
{
    public interface ICategoriaRepository: IGenericRepository<Categoria>
    {

        public  List<Categoria> Search(string keyword);

        //public List<Categoria> Search(decimal min,decimal max);

    }
}
