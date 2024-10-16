using DotNetWebProject.Models;
using DotNetWebProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebProject.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{clientId}")]
        public ActionResult GetClientById(string clientId)
        {
            var client = _clientService.GetClientByID(clientId);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
    }
}
