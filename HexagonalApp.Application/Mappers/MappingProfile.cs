using AutoMapper;
using HexagonalApp.Domain.Dtos;
using HexagonalApp.Domain.Entities;
using HexagonalApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalApp.Application.Mappers
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<ClientEntity, ClientDTO>();
            CreateMap<ClientDTO, ClientEntity>();
            CreateMap<ClientEntity, ClientModel>();
            CreateMap<ClientDTO, ClientModel>();
            CreateMap<ClientModel, ClientDTO>();
            CreateMap<ClientModel, ClientEntity>();
           
            
        }
    }
}
