/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Features.CarPaths.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.EntityFramework.Repositories.CarRepositories;
using Application.Services.MongoDb.CarPathRepositories;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Domain.MongoEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarPaths.Queries
{
    public class GetAllByCarIdCommand : IRequest<IResponse<List<CarPathDto>>>
    {
        #region Properties

        public int CarId { get; set; }

        #endregion Properties
    }

    public class GetAllByCarIdCommandHandler : IRequestHandler<GetAllByCarIdCommand, IResponse<List<CarPathDto>>>
    {
        #region Fields

        private CarBusinessRules _carBusinessRules;
        private ICarPathReadRepository _carPathReadRepository;
        private ICarReadRepository _carReadRepository;
        private IMapper _mapper;

        #endregion Fields

        #region Constructors

        public GetAllByCarIdCommandHandler(ICarReadRepository carReadRepository, ICarPathReadRepository carPathReadRepository, IMapper mapper, CarBusinessRules carBusinessRules)
        {
            _carReadRepository = carReadRepository;
            _carPathReadRepository = carPathReadRepository;
            _mapper = mapper;
            _carBusinessRules = carBusinessRules;
        }

        #endregion Constructors

        #region Methods

        public async Task<IResponse<List<CarPathDto>>> Handle(GetAllByCarIdCommand request, CancellationToken cancellationToken)
        {
            await _carBusinessRules.CarIsExistById(request.CarId);
            Car car = await _carReadRepository.GetByIdAsync(request.CarId);
            // 2022-03-10T11:44:00.000+00:00
            //var test = await _carPathReadRepository.FindAllAsync(p => p.DateTime > new DateTime(2022, 03, 10, 14, 40, 00) && p.DateTime < new DateTime(2022, 03, 10, 15, 40, 00));

            List<CarPath> carPaths = await _carPathReadRepository.FindAllAsync(p => p.NumberPlate == car.NumberPlate);
            List<CarPathDto> carPathDtos = _mapper.Map<List<CarPathDto>>(carPaths);
            return Response<List<CarPathDto>>.Success(carPathDtos, 200);
        }

        #endregion Methods
    }
}