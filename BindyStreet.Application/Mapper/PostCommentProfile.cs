using AutoMapper;
using BindyStreet.Application.DTOs.Post.Request;
using BindyStreet.Application.DTOs.Post.Response;
using BindyStreet.Application.DTOs.PostComment.Request;
using BindyStreet.Application.DTOs.PostComment.Response;
using BindyStreet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Mapper
{
    public class PostCommentProfile : Profile
    {
        public PostCommentProfile()
        {
            CreateMap<Comment, CreatePostCommentRequest>().ReverseMap();
            CreateMap<Comment, UpdatePostCommentRequest>().ReverseMap();
            CreateMap<Comment, GetAllPostCommentDto>().ReverseMap();
            CreateMap<Comment, GetPostCommentByIdDto>().ReverseMap();
        }
    }
}
