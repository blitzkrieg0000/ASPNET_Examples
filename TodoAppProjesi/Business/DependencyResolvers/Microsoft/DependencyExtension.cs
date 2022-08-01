using System;
using AutoMapper;
using Business.Interfaces;
using Business.Mappings.AutoMapper;
using Business.Services;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Business.DependencyResolvers.Microsoft {
    public static class DependencyExtension {

        public static void AddDependencies(this IServiceCollection services) {

            //! DEPENDENCY INJECTIONS
            //Context in OnConfiguring kısmını dependency injection aracılığıyla yapıyoruz.
            services.AddDbContext<TodoContext>(opt => {
                opt.UseSqlServer("server=localhost; user=sa; database=TodoDb; password=DGH2022.");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkService, WorkService>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            //! AUTOMAPPER CONFIGURATIONS
            var configuration = new MapperConfiguration(opt => {
                opt.AddProfile(new WorkProfile());
            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

        }

    }
}