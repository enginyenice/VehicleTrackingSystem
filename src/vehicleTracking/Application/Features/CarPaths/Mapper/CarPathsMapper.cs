/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Features.CarPaths.Dtos;
using AutoMapper;
using Domain.MongoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarPaths.Mapper
{
    public class CarPathsMapper : Profile
    {
        #region Constructors

        public CarPathsMapper()
        {
            CreateMap<CarPath, CarPathDto>().ReverseMap();
        }

        #endregion Constructors
    }
}