using Repository.Pattern.EF.Entities;
using System;
using System.Threading.Tasks;

namespace Repository.Pattern.EF.EFCore
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly DBLibraryContext context;

        public UnitOfWorks(DBLibraryContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    await context.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                    // await dbContextTransaction.RollbackAsync(); //Required according to MSDN article                         

                }
                catch (Exception)
                {
                    await dbContextTransaction.RollbackAsync(); //Required according to MSDN article                         

                }
            }
        }

    }
}
