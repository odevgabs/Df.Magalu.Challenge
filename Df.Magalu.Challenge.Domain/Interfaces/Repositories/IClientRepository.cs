using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Domain.Interfaces.Repositories
{
    public interface IClientRepository: IRepository<IClient>
    {
        Task<IClient> GetByEmail(string email);
    }
}
