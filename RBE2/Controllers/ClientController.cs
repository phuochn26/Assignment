  
using System.Collections.Generic;
using RBE2.Models;
using RBE2.Services;
using Microsoft.AspNetCore.Mvc;

namespace RBE2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public List<Client> List()
        {
            return _clientService.GetList();
        }
        [HttpPost]
        public Client Create(Client client)
        {
            _clientService.Create(client);
            return client;
        }
        [HttpPut("id")]
        public IActionResult Update(int id,Client client)
        {
            if(id == 0)
            {
                return StatusCode(404);
            }
            else
            {
                _clientService.Update(client);
            }
            return StatusCode(200);
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            
            _clientService.Delete(id);
            return StatusCode(200);
        }
    }
}