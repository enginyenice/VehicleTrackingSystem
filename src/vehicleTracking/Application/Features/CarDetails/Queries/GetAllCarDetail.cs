using Application.Features.CarDetails.Dtos;
using Application.Services.MongoDb;
using AutoMapper;
using Core.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarDetails.Queries
{
    public class GetAllCarDetailCommand : IRequest<IResponse<List<CarDetailDto>>>
    {
    }

    public class GetAllCarDetailCommandHandler : IRequestHandler<GetAllCarDetailCommand, IResponse<List<CarDetailDto>>>
    {
        private ICarDetailMongoReadRepository _carDetailMongoReadRepository;
        private IMapper _mapper;

        public GetAllCarDetailCommandHandler(ICarDetailMongoReadRepository carDetailMongoReadRepository, IMapper mapper)
        {
            _carDetailMongoReadRepository = carDetailMongoReadRepository;
            _mapper = mapper;
        }

        public async Task<IResponse<List<CarDetailDto>>> Handle(GetAllCarDetailCommand request, CancellationToken cancellationToken)
        {
            var carDetails = await _carDetailMongoReadRepository.GetAllAsync();
            List<CarDetailDto> carDetailListDto = _mapper.Map<List<CarDetailDto>>(carDetails);
            return Response<List<CarDetailDto>>.Success(carDetailListDto, 200);
        }
    }
}