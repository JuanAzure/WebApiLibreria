using System.Threading.Tasks;

namespace Library.Repo.SqlServer.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
