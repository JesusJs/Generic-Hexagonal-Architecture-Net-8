using HexagonalApp.Domain.Entities;
using HexagonalApp.Domain.Interfaces.Repository;
using HexagonalApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HexagonalApp.Infrastructure.Repository
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly HexagonalAppContext _db;
        private readonly ILogger<ClientsRepository> _logger;
        public ClientsRepository(HexagonalAppContext db, ILogger<ClientsRepository> logger) 
        { 
            this._db = db;
            this._logger = logger;
        }

        public async void CreateAsync(ClientEntity Client)
        {
            
            try
            {
                await _db.Clients.AddAsync(Client);
                await _db.SaveChangesAsync();
                _logger.LogInformation($"Client {Client} create success .", Client.ClientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error to create {Client}.", Client.ClientId);
                throw;
            }
        }

        public  async Task DeleteAsync(ClientEntity Client)
        {

            try 
            {
                _db.Remove(Client);
                await _db.SaveChangesAsync(true);
                _logger.LogInformation($"Client {Client} delete witch success.", Client);
            }
            catch (Exception ex) {

                _logger.LogError(ex, $"Error to delete client {Client}.", Client);
                throw;
            }
        }

        public async Task<ClientEntity> GetFirstDateAsync(int ClientId)
        {
            try {
                return await _db.Clients.Where(e => e.ClientId == ClientId).FirstAsync();
            }
            catch (Exception ex) {
                _logger.LogError(ex, $"Error to get client {ClientId}.", ex);
                throw;
            }
        }

        public async Task<bool> GetClientExist(int ClientId)
        {
            try
            {
                return await _db.Clients.Where(e => e.ClientId == ClientId).AnyAsync();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Error to get client {ClientId}.", ex);
                throw;
            }
        }

        public async Task<List<ClientEntity>> GetAsync()
        {
            try
            {
                return await _db.Clients.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to get clients.");
                throw;
            }
            
        }

        public async Task UpdateAsync(ClientEntity Client)
        {
            try
            {
                _db.Clients.Update(Client);
                await _db.SaveChangesAsync();
                _logger.LogInformation($"Client {Client} update witch success.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error to update clients. {Client}", ex);
                throw;
            }
            
        }
    }
}
