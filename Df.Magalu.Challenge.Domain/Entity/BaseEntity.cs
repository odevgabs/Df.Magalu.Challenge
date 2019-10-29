using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Df.Magalu.Challenge.Domain.Entity
{
    public class BaseEntity : IEntity
    {
        public BaseEntity()
        {
        }

        public Guid _id { get; private set; }
    }
}
