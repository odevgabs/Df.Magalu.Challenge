using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext _context;
        protected readonly IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual void Create(TEntity obj)
        {
             _context.AddCommand(async () => await DbSet.InsertOneAsync(obj));
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.FirstOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }


        public virtual void Remove(Guid id)
        {
            DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)).GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
