using Library.Repo.SqlServer.DBModelCliente;
using Library.Repo.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repo.SqlServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestauranntDBContext context;

        public UnitOfWork(RestauranntDBContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
            
        }
    }
}
