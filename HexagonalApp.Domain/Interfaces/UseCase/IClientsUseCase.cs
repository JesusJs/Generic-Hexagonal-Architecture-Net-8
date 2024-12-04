using HexagonalApp.Domain.Dtos;
using HexagonalApp.Domain.Entities;
using HexagonalApp.Domain.Models;
using HexagonalApp.Domain.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalApp.Domain.Interfaces.UseCase
{
    public interface IClientsUseCase
    {
        Task<Result<ClientModel>> CreateAsync(ClientDTO Client);
        Task<Result<string>> DeleteAsync(int ClientId);
        Task<Result<List<ClientModel>>> GetAsync();
        Task<Result<ClientModel>> UpdateAsync(ClientModel Client);
    }
}
