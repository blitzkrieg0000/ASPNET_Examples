using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using jwtapp.back.Core.Application.Dto;
using Microsoft.IdentityModel.Tokens;

namespace jwtapp.back.Infrastructure.Tools
{
    public static class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            var customClaims = new List<Claim>();
            if (!string.IsNullOrEmpty(dto.Role))
            {
                customClaims.Add(new Claim(ClaimTypes.Role, dto.Role));
            }
           
           customClaims.Add(new Claim(ClaimTypes.NameIdentifier,dto.Id.ToString()));
            
            if(!string.IsNullOrEmpty(dto.Username))
                customClaims.Add(new Claim(ClaimTypes.Name,dto.Username));

            var securitykey =new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes("ferhatferhatferhat05"));

            SigningCredentials credentials = new(securitykey,SecurityAlgorithms.HmacSha256);
            
            var expireDate  = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new(issuer:
            JwtTokenDefaults.ValidIssuer,
            audience:JwtTokenDefaults.ValidAudience,
            claims:customClaims,
            notBefore:DateTime.UtcNow, 
            expires: expireDate,
            signingCredentials:credentials);

            JwtSecurityTokenHandler handler = new();
            // handler.WriteToken()
            return new TokenResponseDto(handler.WriteToken(token),expireDate);
        }
    }
}