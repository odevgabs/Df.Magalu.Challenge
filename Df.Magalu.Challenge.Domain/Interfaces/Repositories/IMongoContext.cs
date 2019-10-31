using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Domain.Interfaces.Repositories
{
    public interface IMongoContext
    {
        IMongoClient MongoClient { get; }
        IClientSessionHandle Session { get; set; }
        List<Func<Task>> _commands { get; }
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
        void AddCommand(Func<Task> func);
        void Dispose();
    }
}
