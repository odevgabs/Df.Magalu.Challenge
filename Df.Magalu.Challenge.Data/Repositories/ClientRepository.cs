using Df.Magalu.Challenge.Domain.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Data.Repositories
{
    public class ClientRepository : BaseRepository<IClient>, IClientRepository
    {
        public ClientRepository(IMongoContext context) : base(context)
        {
        }
    }
}
