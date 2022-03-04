using Application.Services.Repositories;
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
        private IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserIsExist(string name, string hashPassword)
        {
            if (await _userRepository.IsExist(p => p.Username == name && p.PasswordHash == hashPassword) == false)
                throw new BusinessException("User not found", 404);
        }
    }
}