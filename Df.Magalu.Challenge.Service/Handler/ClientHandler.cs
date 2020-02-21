using Df.Magalu.Challenge.Service.Handler.Contracts;
using Df.Magalu.Challenge.Service.Interfaces;
using Df.Message.Broker.ServiceBus.Standard.Contracts;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Service.Handler
{
    public class ClientHandler: IClientHandler
    {
        private IConsumer _consumer;
        private IClientService _clientService;
        public ClientHandler(IConsumer consumer, IClientService clientService)
        {
            _consumer = consumer;
            _clientService = clientService;
        }

    
        public async Task Process()
        {
            // Func<Task> func = (clientCreateRequest)=> _clientService.Create(clientCreateRequest)

            // _consumer.RegisterOnMessageHandlerAndReceiveMessages(() => )
            return;
        }

    }
}
