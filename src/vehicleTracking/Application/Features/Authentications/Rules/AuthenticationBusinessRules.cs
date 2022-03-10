/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Services.EntityFramework.Repositories.UserRepositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Authentications.Rules
{
    public class AuthenticationBusinessRules
    {
        #region Fields

        private IUserReadRepository _userReadRepository;

        #endregion Fields

        #region Constructors

        public AuthenticationBusinessRules(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        #endregion Constructors

        #region Methods

        public async Task UserIsExist(string name, string hashPassword)
        {
            if (await _userReadRepository.IsExist(p => p.Username == name && p.PasswordHash == hashPassword, tracking: false) == false)
                throw new BusinessException("User not found", 404);
        }

        #endregion Methods
    }
}