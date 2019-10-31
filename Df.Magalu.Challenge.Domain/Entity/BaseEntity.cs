using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Df.Magalu.Challenge.Domain.Entity
{
    public class BaseEntity<T> : IEntity
    {
        public Guid _id { get; private set; }

        public DateTime CreationDate { get; private set; }
    }
}
