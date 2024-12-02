using AuthForm.Dto.Dtos.AuthDto;
using AuthForm.Dto.Dtos.UserDto;
using AuthForm.Infrastucture.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, GetUserDto>().ReverseMap();
            CreateMap<AuthGetDto, GetUserDto>().ReverseMap();
            CreateMap<CreateUserDto, UserModel>();
            CreateMap<UpdateUserDto, UserModel>();
            CreateMap<EmailConfirmDto, AuthGetDto>();

        }
    }
}
