using AutoMapper;
using Df.Magalu.Challenge.Grpc.Protos;
using Df.Magalu.Challenge.Service.Interfaces;
using Df.Magalu.Challenge.Service.Requests.Client;
using Grpc.Core;
using System.Threading.Tasks;

namespace Df.Magalu.Challenge.Grpc
{
    public class ClientGrpcService : ClientGrpc.ClientGrpcBase
    {

        private readonly IClientService _clientService;
        private IMapper _mapper;

        public ClientGrpcService(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }
        //public ClientGrpcService()
        //{
        //}

        public override Task<CreateResponseGrpc> Create(CreateRequestGrpc request, ServerCallContext context)
        {
            //ClientCreateRequest clientCreateRequest = _mapper.Map<ClientCreateRequest>(request);

            //var result = _clientService.Create(clientCreateRequest).GetAwaiter().GetResult();
            return Task.FromResult(new CreateResponseGrpc
            { Success = true });
        }

    }
}
