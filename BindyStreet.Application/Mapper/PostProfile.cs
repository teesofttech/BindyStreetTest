using AutoMapper;
using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.DTOs.Post.Response;
using BindyStreet.Application.DTOs.User.UserRequest;
using BindyStreet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Mapper
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, CreatePostRequest>().ReverseMap();
            CreateMap<Post, UpdatePostRequest>().ReverseMap();
            CreateMap<Post, GetAllPostDto>().ReverseMap();
            CreateMap<Post, GetPostByIdDto>().ReverseMap();
        }
    }
}
