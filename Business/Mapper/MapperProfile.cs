using AutoMapper;
using Data.DTO;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserModel, LoginDto>();
            CreateMap<UserModel, UserDto>();
            CreateMap<UserDto, UserModel>();

        }
    }
}
