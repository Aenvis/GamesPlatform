using AutoMapper;
using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {  
            CreateMap<User, UserDto>();
            CreateMap<IEnumerable<UserDto>, IEnumerable<User>>();
        }
    }
}
