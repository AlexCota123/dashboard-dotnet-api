using System;
using AutoMapper;
using Dashboard.Dtos;
using Dashboard.Models;

namespace Dashboard.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}
