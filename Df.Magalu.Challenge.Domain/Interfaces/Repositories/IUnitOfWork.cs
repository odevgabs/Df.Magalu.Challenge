using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        void Dispose();
    }
}
