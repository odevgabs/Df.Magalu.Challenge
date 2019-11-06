using Df.Magalu.Challenge.Grpc.Protos;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Grpc.Client
{
    public class Program
    {
        private const string SERVER_GRPC = "http://localhost:5000";
        static async Task Main()
        {

            if (!SERVER_GRPC.StartsWith("https"))
            {
                AppContext.SetSwitch(
                    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            }

            var channel = GrpcChannel.ForAddress(SERVER_GRPC);
            var client = new ClientGrpc.ClientGrpcClient(channel);

            var reply = await client.CreateAsync(new CreateRequestGrpc
            {
                Name = "Teste2",
                Email = "Teste2"
            });

            Console.WriteLine(reply.Success);
        }
    }
}
