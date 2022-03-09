using Application.Features.CarDetails.Dtos;
using Application.Services.MongoDb;
using AutoMapper;
using Core.Application.Responses;
using Domain.MongoEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarDetails.Commands
{
    public class CreateCarDetailCommand : IRequest<IResponse<CarDetailDto>>
    {
        public int ValueOne { get; set; }
        public string ValueTwo { get; set; }
    }

    public class CreateCarDetailCommandHandler : IRequestHandler<CreateCarDetailCommand, IResponse<CarDetailDto>>
    {
        private ICarDetailMongoWriteRepository _carDetailMongoWriteRepository;
        private IMapper _mapper;

        public CreateCarDetailCommandHandler(ICarDetailMongoWriteRepository carDetailMongoWriteRepository, IMapper mapper)
        {
            _carDetailMongoWriteRepository = carDetailMongoWriteRepository;
            _mapper = mapper;
        }

        public async Task<IResponse<CarDetailDto>> Handle(CreateCarDetailCommand request, CancellationToken cancellationToken)
        {
            var carDetail = _mapper.Map<CarDetail>(request);
            await _carDetailMongoWriteRepository.CreateAsync(carDetail);
            var carDetailDto = _mapper.Map<CarDetailDto>(carDetail);
            return Response<CarDetailDto>.Success(carDetailDto, 200);
        }
    }
}