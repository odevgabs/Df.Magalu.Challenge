using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Df.Magalu.Challenge.Service.Interfaces;
using Df.Magalu.Challenge.Service.Requests.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Df.Magalu.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateRequest request)
        {
            try
            {
                var client = await _clientService.Create(request);
                return Ok();
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}