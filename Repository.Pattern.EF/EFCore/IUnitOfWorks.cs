using System.Threading.Tasks;

namespace Repository.Pattern.EF.EFCore
{
    public interface IUnitOfWorks
    {
        Task CompleteAsync();
    }


}
