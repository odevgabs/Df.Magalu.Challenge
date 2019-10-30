using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Df.Magalu.Challenge.Domain.Interfaces.Factories
{
    public interface IClientFactory
    {
        IClient Create(string name, string email);
    }
}
