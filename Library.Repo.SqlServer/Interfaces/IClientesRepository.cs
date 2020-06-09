using Library.Repo.SqlServer.DBModelCliente;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repo.SqlServer.Interfaces
{
    public interface IClientesRepository
    {
        Task<IQueryable<Clientes>> ObtenerClientes();
        Task<Clientes> ObtenerClienteIdAsync(int id);
        Task AgregarClienteAsync(Clientes cli);
        void EliminarCliente(Clientes cli);
    }
}
