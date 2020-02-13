using Df.Magalu.Challenge.Domain.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Data.Repositories
{
    public class ClientRepository : BaseRepository<IClient>, IClientRepository
    {

        protected readonly IMongoCollection<IClient> _dbSet;
        public ClientRepository(IMongoContext context) : base(context)
        {
            _dbSet = context.GetCollection<IClient>(typeof(IClient).Name);
        }

         public virtual async Task<IClient> GetByEmail(string email)
        {
            var data = await _dbSet.FindAsync(Builders<IClient>.Filter.Eq("Email", email));
            return data.FirstOrDefault();
        }
    }
}
