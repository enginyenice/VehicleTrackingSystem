using Application.Features.Cars.Dtos;
using Application.Services.EntityFramework.Repositories.CarRepositories;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries
{
    public class GetAllByUserIdCommand : IRequest<IResponse<List<CarDto>>>
    {
        public int UserId { get; set; }
    }

    public class GetAllByUserIdCommandHandler : IRequestHandler<GetAllByUserIdCommand, IResponse<List<CarDto>>>
    {
        private ICarReadRepository _carReadRepository;
        private IMapper _mapper;

        public GetAllByUserIdCommandHandler(ICarReadRepository carReadRepository, IMapper mapper)
        {
            _carReadRepository = carReadRepository;
            _mapper = mapper;
        }

        public async Task<IResponse<List<CarDto>>> Handle(GetAllByUserIdCommand request, CancellationToken cancellationToken)
        {
            List<Car> cars = _carReadRepository.Query().Where(p => p.UserId == request.UserId).ToList();
            List<CarDto> carsDto = _mapper.Map<List<CarDto>>(cars);
            return Response<List<CarDto>>.Success(carsDto, 200);
        }
    }
}