using Df.Magalu.Challenge.Domain.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Entity;
using Df.Magalu.Challenge.Domain.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Df.Magalu.Challenge.Domain.Factories
{
    public class ClientFactory: IClientFactory
    {
        public IClient Create(string name, string email)
        {
            IClient client = new Client(name, email);
            return client;
        }

    }
}
