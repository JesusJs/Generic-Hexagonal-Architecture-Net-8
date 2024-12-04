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
    public class AutoMapper
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ClientEntity, ClientDTO>();
                    cfg.CreateMap<ClientDTO, ClientEntity>();
                    cfg.CreateMap<ClientModel, ClientDTO>();
                    cfg.CreateMap<ClientDTO, ClientModel>();
                });
            });
            return config.CreateMapper();
        });
        public static IMapper GetMapper()
        {
            return _mapper.Value;
        }
    }
}
