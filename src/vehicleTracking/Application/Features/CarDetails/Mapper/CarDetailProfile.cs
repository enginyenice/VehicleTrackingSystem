using Application.Features.CarDetails.Commands;
using Application.Features.CarDetails.Dtos;
using AutoMapper;
using Domain.MongoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarDetails.Mapper
{
    public class CarDetailProfile : Profile
    {
        public CarDetailProfile()
        {
            CreateMap<CarDetail, CarDetailDto>().ReverseMap();
            CreateMap<CreateCarDetailCommand, CarDetail>();
        }
    }
}