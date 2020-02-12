using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            int changesResult = await _context.SaveChanges().ConfigureAwait(false);
            bool result = changesResult > 0;
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}