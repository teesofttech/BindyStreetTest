using AutoMapper;
using BindyStreet.Application.DTOs.User.Response;
using BindyStreet.Application.DTOs.User.UserRequest;
using BindyStreet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindyStreet.Application.Mapper
{
    public class GeoProfile : Profile
    {
        public GeoProfile()
        {
            CreateMap<Geo, GeoDto>().ReverseMap();
        }
    }
}
