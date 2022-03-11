/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Services.EntityFramework.Repositories.CarRepositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Rules
{
    public class CarBusinessRules
    {
        #region Fields

        private ICarReadRepository _carReadRepository;

        #endregion Fields

        #region Constructors

        public CarBusinessRules(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        #endregion Constructors

        #region Methods

        public async Task CarIsExistById(int Id)
        {
            var car = await _carReadRepository.GetByIdAsync(Id);
            if (car == null) throw new BusinessException("Car Not Found", 404);
        }

        #endregion Methods
    }
}