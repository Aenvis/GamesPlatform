using AutoMapper;
using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.AutoMappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            }).CreateMapper();
        }
    }
}
