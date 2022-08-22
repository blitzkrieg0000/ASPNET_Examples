using System;
using AutoMapper;
using Business.Interfaces;
using Business.Mappings.AutoMapper;
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
            services.AddDbContext<TennisContext>(opt => {
                opt.UseNpgsql("Host=localhost;Database=tenis;Username=tenis;Password=2sfcNavA89A294V4");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPlayingDatumService, PlayingDatumService>();
            services.AddScoped<IStreamService, StreamService>();
            services.AddScoped<IGRPCService, GRPCService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IAosTypeService, AosTypeService>();
            services.AddScoped<ICourtService, CourtService>();
            services.AddScoped<ICourtTypeService, CourtTypeService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IGenericService, GenericService>();
            services.AddScoped<IProcessService, ProcessService>();
            services.AddScoped<IProcessParameterService, ProcessParameterService>();

            //! AUTOMAPPER CONFIGURATIONS
            var configuration = new MapperConfiguration(opt => {
                opt.AddProfile(new TennisProfile());
            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            //! GRPC
            services.AddGrpc();
        }

    }
}