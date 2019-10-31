using System;
using System.Collections.Generic;
using System.Text;

namespace Df.Magalu.Challenge.Domain.Interfaces.Entity
{
    public interface IEntity
    {
        Guid _id { get; }
        DateTime CreationDate { get; }
    }
}
