using Application.Services.Repositories;
using Application.Services.Repositories.UserRepositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Rules
{
    public class UserBusinessRules
    {
        private IUserReadRepository _userReadRepository;

        public UserBusinessRules(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task UserIsExist(string name, string hashPassword)
        {
            if (await _userReadRepository.IsExist(p => p.Username == name && p.PasswordHash == hashPassword) == false)
                throw new BusinessException("User not found", 404);
        }
    }
}