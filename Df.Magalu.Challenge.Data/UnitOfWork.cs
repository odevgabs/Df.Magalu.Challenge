using Df.Magalu.Challenge.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Df.Magalu.Challenge.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            int changesResult = _context.SaveChanges().GetAwaiter().GetResult();
            bool result = changesResult > 0;
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}