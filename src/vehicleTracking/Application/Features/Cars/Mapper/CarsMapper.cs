using Application.Features.Cars.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Mapper
{
    public class CarsMapper : Profile
    {
        public CarsMapper()
        {
            CreateMap<Car, CarDto>().ReverseMap();
        }
    }
}