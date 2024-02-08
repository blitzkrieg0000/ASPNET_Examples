using Application.Abstractions;
using Application.Abstractions.Repository.Menu;
using Application.Abstractions.Repository.Role;
using Application.Abstractions.Repository.User;
using Application.Abstractions.Repository.UserClaim;
using Application.Abstractions.Repository.UserRole;
using Application.Interfaces.Service.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Repositories.Menu;
using Persistence.Repositories.Role;
using Persistence.Repositories.User;
using Persistence.Repositories.UserClaim;
using Persistence.Repositories.UserRole;
using Persistence.Services.Auth;

namespace Persistence;


public static class ServiceRegistration {

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {

        // HttpContext'e DI ile ulaşabilmek için gerekli
        services.AddHttpContextAccessor();
        
        // DBContext
        services.AddDbContext<DefaultContext>(opt => {
            opt.UseNpgsql(configuration.GetConnectionString("Default"));
            opt.LogTo(Console.WriteLine, LogLevel.Information);
        });

        //! Respositories
        services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
        services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
        services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        services.AddScoped<IUserQueryRepository, UserQueryRepository>();
        services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();
        services.AddScoped<IRoleCommandRepository, RoleCommandRepository>();
        services.AddScoped<IUserRoleQueryRepository, UserRoleQueryRepository>();
        services.AddScoped<IUserRoleCommandRepository, UserRoleCommandRepository>();
        
        services.AddScoped<IApplicationUserClaimCommandRepository, ApplicationUserClaimCommandRepository>();
        services.AddScoped<IApplicationUserClaimQueryRepository, ApplicationUserClaimQueryRepository>();
        services.AddScoped<IMenuQueryRepository, MenuQueryRepository>();
        services.AddScoped<IMenuCommandRepository, MenuCommandRepository>();

        //! Services
        services.AddScoped<ICustomAuthService, CustomAuthService>();
        services.AddScoped<IUserManagerService, UserManagerService>();
        services.AddScoped<IRoleManagerService, RoleManagerService>();
    }

}
