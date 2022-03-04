using Core.Security.Encryption;
using Core.Security.Entities;
using Core.Security.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private TokenOption _tokenOption;

        public JwtHelper(IOptions<TokenOption> tokenOption)
        {
            _tokenOption = tokenOption.Value;
        }

        public AccessToken CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = CreateSecurityKeyHelper.CreateSecurityKey(_tokenOption.SecurityKey);

            var expireDate = DateTime.UtcNow.AddHours(_tokenOption.Expires);
            List<Claim> claims = new List<Claim>();
            claims.AddUsername(user.Username);
            claims.AddNameIdentifier(user.Id);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expireDate,
                SigningCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            AccessToken accessToken = new AccessToken
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = expireDate
            };
            return accessToken;
        }
    }
}