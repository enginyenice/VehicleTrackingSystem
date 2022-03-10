/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Features.Cars.Dtos;
using Application.Services.EntityFramework.Repositories.CarRepositories;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries
{
    public class GetAllByUserIdCommand : IRequest<IResponse<List<CarDto>>>
    {
        #region Properties

        public int UserId { get; set; }

        #endregion Properties
    }

    public class GetAllByUserIdCommandHandler : IRequestHandler<GetAllByUserIdCommand, IResponse<List<CarDto>>>
    {
        #region Fields

        private ICarReadRepository _carReadRepository;
        private IMapper _mapper;

        #endregion Fields

        #region Constructors

        public GetAllByUserIdCommandHandler(ICarReadRepository carReadRepository, IMapper mapper)
        {
            _carReadRepository = carReadRepository;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<IResponse<List<CarDto>>> Handle(GetAllByUserIdCommand request, CancellationToken cancellationToken)
        {
            List<Car> cars = _carReadRepository.Query().Where(p => p.UserId == request.UserId).ToList();
            List<CarDto> carsDto = _mapper.Map<List<CarDto>>(cars);
            return Response<List<CarDto>>.Success(carsDto, 200);
        }

        #endregion Methods
    }
}