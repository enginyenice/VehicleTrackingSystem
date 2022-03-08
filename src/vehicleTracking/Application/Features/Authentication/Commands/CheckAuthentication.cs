using Application.Features.Authentication.Dtos;
using Application.Features.Authentication.Rules;
using Application.Services.Repositories;
using Application.Services.Repositories.UserRepositories;
using Core.Application.Responses;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.Jwt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Commands
{
    public class CheckAuthenticationCommand : IRequest<IResponse<AccessToken>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class CheckAuthenticationCommandHandler : IRequestHandler<CheckAuthenticationCommand, IResponse<AccessToken>>
    {
        private AuthenticationBusinessRules _authenticationBusinessRules;
        private ITokenHelper _tokenHelper;
        private IUserReadRepository _userReadRepository;

        public CheckAuthenticationCommandHandler(AuthenticationBusinessRules authenticationBusinessRules, ITokenHelper tokenHelper, IUserReadRepository userReadRepository)
        {
            _authenticationBusinessRules = authenticationBusinessRules;
            _tokenHelper = tokenHelper;
            _userReadRepository = userReadRepository;
        }

        public async Task<IResponse<AccessToken>> Handle(CheckAuthenticationCommand request, CancellationToken cancellationToken)
        {
            string hashPassword = HashingHelper.HashPassword(request.Password);
            await _authenticationBusinessRules.UserIsExist(request.Username, hashPassword);

            User user = await _userReadRepository.GetAsync(p => p.Username == request.Username && p.PasswordHash == hashPassword);
            AccessToken accessToken = _tokenHelper.CreateToken(user);
            return Response<AccessToken>.Success(accessToken, 200);
        }
    }
}