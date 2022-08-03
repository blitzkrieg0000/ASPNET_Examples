using System;
using Business.Interfaces;
using Business.Services;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UI.Entities.Concrete;

namespace Business.DependencyResolvers.Microsoft {
    public static class DependencyExtension {

        public static void AddDependencies(this IServiceCollection services) {

            //! DEPENDENCY INJECTIONS
            //Context in OnConfiguring kısmını dependency injection aracılığıyla yapıyoruz.
            services.AddDbContext<TenisContext>(opt => {
                opt.UseNpgsql("Host=localhost;Database=tenis;Username=tenis;Password=2sfcNavA89A294V4");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITennisService, TennisService>();
        }

    }
}