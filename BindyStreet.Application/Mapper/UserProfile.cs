using AutoMapper;
using BindyStreet.Application.DTOs.User.Request;
using BindyStreet.Application.DTOs.User.Response;
using BindyStreet.Application.DTOs.User.UserRequest;
using BindyStreet.Application.Features.UserFeatures.Queries.GetUserById;
using BindyStreet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequest, User>().ReverseMap();
            CreateMap<User, GetAllUsersDto>().ReverseMap();
            CreateMap<User, GetUserByIdDto>().ReverseMap();
            CreateMap<GetUserByIdDto, User>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();
        }
    }
}
