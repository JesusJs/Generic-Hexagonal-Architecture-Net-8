using HexagonalApp.Domain.Dtos;
using HexagonalApp.Domain.Interfaces.Repository;
using HexagonalApp.Domain.Interfaces.UseCase;
using HexagonalApp.Domain.Models;
using HexagonalApp.Domain.Shared;
using HexagonalApp.Domain.Entities;
using AutoMapper;
using Serilog;
using Microsoft.Extensions.Logging;
namespace HexagonalApp.Application.UseCase
{
    public class ClientsUseCase : IClientsUseCase
    {
        private IClientsRepository _repository;
        private readonly IMapper mapper;
        private readonly ILogger<IClientsUseCase> _logger;

        public ClientsUseCase(IClientsRepository ClientsRepository, IMapper _Mapper, ILogger<IClientsUseCase> logger) 
        { 
            this._repository = ClientsRepository;
            this.mapper = _Mapper;
            this._logger = logger;
        }

        public async Task<Result<ClientModel>> CreateAsync(ClientDTO Clients)
        {
            try 
            {
                if (Clients == null ) 
                    return Result<ClientModel>.Fail("No find properties for creating.");

                var ExistingData = await _repository.GetClientExist(Clients.ClientId);

                if (!ExistingData)
                {
                    var MapperEntity = mapper.Map<ClientEntity>(Clients);
                    _repository.CreateAsync(MapperEntity);
                    var Data = await _repository.GetFirstDateAsync(Clients.ClientId);
                    return Result<ClientModel>.Ok(mapper.Map<ClientModel>(Data));
                }
                else 
                {
                    return Result<ClientModel>.Fail("The client you want to create already exists.");
                }
            }
            catch (Exception Ex) 
            {
                _logger.LogError(Ex,"An error occurred while creating");
                return Result<ClientModel>.Fail($"An error occurred while creating  {Ex}");
            }
        }

        public async Task<Result<string>> DeleteAsync(int ClientId)
        {
            try
            {
                var GetClient = await _repository.GetClientExist(ClientId);

                if (GetClient)
                {
                    var Data = await _repository.GetFirstDateAsync(ClientId);
                    await _repository.DeleteAsync(Data);
                    return Result<string>.OkMessage("Client successfully deleted");
                }
                else
                {
                    return Result<string>.Fail("The client you want to delete no exists");
                }
               
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "An error occurred while deleting client.");
                return Result<string>.Fail($"An error occurred while deleting client. {Ex}");
            }
        }

        public async Task<Result<List<ClientModel>>> GetAsync()
        {
            try
            {
                var result = await _repository.GetAsync();
                return Result<List<ClientModel>>.Ok(mapper.Map<List<ClientModel>>(result));
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex,"An error occurred to get clients.");
                return Result<List<ClientModel>>.Fail($"An error occurred to get clients. {Ex}");
            }
        }

        public async Task<Result<ClientModel>> UpdateAsync(ClientModel Client)
        {
            try
            {
                if (Client == null)
                    return Result<ClientModel>.Fail("The client to update null.");

                var existingData = await _repository.GetClientExist(Client.ClientId);

                if (existingData)
                {
                    var mapperEntity = mapper.Map<ClientEntity>(Client);
                    await _repository.UpdateAsync(mapperEntity);
                    var data = await _repository.GetFirstDateAsync(Client.ClientId);
                    var dtoList = mapper.Map<ClientModel>(data);
                    return Result<ClientModel>.Ok(dtoList);
                }
                else
                {
                    return Result<ClientModel>.Fail("The client you want update no exists.");
                }
            }
            catch ( Exception Ex) 
            {
                _logger.LogError(Ex,"An occurred error to update data.");
                return Result<ClientModel>.Fail($"An occurred error to update data. {Ex}");
            }
        }
    }
}
