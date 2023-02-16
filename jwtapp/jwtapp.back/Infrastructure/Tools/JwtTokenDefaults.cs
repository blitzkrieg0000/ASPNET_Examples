using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtapp.back.Infrastructure.Tools
{
    public class JwtTokenDefaults
    {
        /*
         ValidateAudience="http://localhost",
        ValidateIssuer="http://localhost",
        ClockSkew = TimeSpan.Zero, //Token ile sunucu arasında saar farkı olsun mu ?
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ferhat1")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        */
        public const string ValidAudience ="http://localhost";
        public const string ValidIssuer ="http://localhost";
        public const string Key = "ferhat05";
        public const int Expire = 5; 

    }
}