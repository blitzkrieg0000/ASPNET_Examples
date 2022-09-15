using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApi {
    public class JwtTokenGenerator {
        public string GenerateToken() {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes("blitzkriegblitz."));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new() {
                new Claim(ClaimTypes.Role, "Member")
            };

            JwtSecurityToken token = new(
                issuer: "http://localhost",
                claims: null,
                audience: "http://localhost",
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials
            );

            JwtSecurityTokenHandler handler = new();
            return handler.WriteToken(token);
        }
    }
}