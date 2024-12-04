using AutoMapper;
using HexagonalApp.Domain.Dtos;
using HexagonalApp.Domain.Interfaces.UseCase;
using HexagonalApp.Domain.Models;
using HexagonalApp.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientsUseCase _clientsUse;
        private readonly IMapper mapper;

        public ClientsController(IClientsUseCase clientUse, IMapper _mapper, ILogger<ClientsController> logger)
        {
            this._logger = logger;
            _clientsUse = clientUse;
            mapper = _mapper;
        }

        [HttpPost(Name = "CreateClients")]
        public async Task<IActionResult> CreateAsync(ClientDTO Client)
        {
            _logger.LogInformation("Request for creating an client received: {Data}", Client);
            var clients = await _clientsUse.CreateAsync(Client);
            var data = mapper.Map<ClientDTO>(clients.Data);
                return Ok(new Response<ClientDTO> { StatusCode = 200, Data = data, Message = clients.Message });
        }

        [HttpGet(Name = "GetClients")]
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogInformation("Request for get clients");
            var result = await _clientsUse.GetAsync();
            var data = mapper.Map<List<ClientDTO>>(result.Data);
            return Ok(new Response<List<ClientDTO>> { StatusCode = 200, Data = data, Message = result.Message });
        }

        [HttpDelete(Name = "DeleteClients")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            _logger.LogInformation("Request for delete an client received: {Id}", Id);
            var result = await _clientsUse.DeleteAsync(Id);
            return Ok(new Response<string> { StatusCode = 200, Message = result.Message});
        }

        [HttpPost(Name = "UpdateClients")]
        public async Task<IActionResult> UpdateAsync(ClientDTO Data)
        {
            _logger.LogInformation("Request for updating an client received: {Data}", Data);
            var clients = mapper.Map<ClientModel>(Data);
            var result = await _clientsUse.UpdateAsync(clients);
            var Client = mapper.Map<ClientDTO>(result);
            return Ok(new Response<ClientDTO> { StatusCode = 200, Data =  Client, Message = result.Message});
        }
    }
}
