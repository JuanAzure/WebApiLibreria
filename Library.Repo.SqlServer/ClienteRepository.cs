using Library.Repo.SqlServer.DBModelCliente;
using Library.Repo.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repo.SqlServer
{
    public class ClienteRepository : IClientesRepository
    {
        private readonly RestauranntDBContext context;

        public ClienteRepository(RestauranntDBContext context)
        {
            this.context = context;
        }
                
        public async Task AgregarClienteAsync(Clientes cli)
        {
             await this.context.AddAsync(cli);
        }

        public void EliminarCliente(Clientes cli)
        {
            this.context.Remove(cli);
        }

        public async Task<Clientes> ObtenerClienteIdAsync(int id)
        {
            return await this.context.Clientes
                .Include(d => d.CliDirecciones)
                .Include(t => t.CliTelefonos)
                .FirstOrDefaultAsync(cli => cli.Id == id);
                
        }

        public async Task<IQueryable<Clientes>> ObtenerClientes()
        {

            var IQclientes = await this.context.Clientes
                                                      .Include(d => d.CliDirecciones)
                                                      .Include(t => t.CliTelefonos)
                                                      .ToListAsync();
            return  IQclientes.AsQueryable();

        }
    }
}
