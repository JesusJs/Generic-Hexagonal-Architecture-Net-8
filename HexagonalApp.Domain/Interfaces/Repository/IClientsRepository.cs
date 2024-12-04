using HexagonalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalApp.Domain.Interfaces.Repository
{
    public interface IClientsRepository
    {
        void CreateAsync(ClientEntity Client);
        Task DeleteAsync(ClientEntity Client);
        Task<List<ClientEntity>> GetAsync();
        Task UpdateAsync(ClientEntity Client);
        Task<ClientEntity> GetFirstDateAsync(int ClientId);
        Task<bool> GetClientExist(int ClientId);
    }
}
