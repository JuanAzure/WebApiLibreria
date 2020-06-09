using Microsoft.EntityFrameworkCore;
using Repository.Pattern.EF.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Pattern.EF.EFCore
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DBLibraryContext _dbcontext;

        public GenericRepository(DBLibraryContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbcontext.Set<TEntity>().AsNoTracking();
        }


        public async Task<TEntity> GetById(int id)
        {
            return await _dbcontext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task Create(TEntity entity)
        {
            await _dbcontext.Set<TEntity>().AddAsync(entity);
            //await _dbcontext.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            _dbcontext.Set<TEntity>().Update(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _dbcontext.Set<TEntity>().FindAsync(id);
            if (entity.Id > 0)
                _dbcontext.Set<TEntity>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

    }
}
