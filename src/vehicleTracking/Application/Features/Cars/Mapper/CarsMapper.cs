/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Features.Cars.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Cars.Mapper
{
    public class CarsMapper : Profile
    {
        #region Constructors

        public CarsMapper()
        {
            CreateMap<Car, CarDto>().ReverseMap();
        }

        #endregion Constructors
    }
}