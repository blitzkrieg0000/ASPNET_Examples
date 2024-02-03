using Application.Interfaces.Repository;
using Application.Interfaces.Repository.Endpoint;
using Application.Interfaces.Repository.File;
using Application.Interfaces.Repository.File.Common.DocumentFile;
using Application.Interfaces.Repository.File.Common.ImageFile;
using Application.Interfaces.Repository.File.Common.InvoiceFile;
using Application.Interfaces.Repository.File.Common.OtherFile;
using Application.Interfaces.Repository.File.Common.VideoFile;
using Application.Interfaces.Repository.Menu;
using Application.Interfaces.Repository.Role;
using Application.Interfaces.Repository.User;
using Application.Interfaces.Repository.UserClaim;
using Application.Interfaces.Repository.UserRole;
using Application.Interfaces.Service.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Repositories.Endpoint;
using Persistence.Repositories.File;
using Persistence.Repositories.File.Common.DocumentFile;
using Persistence.Repositories.File.Common.ImageFile;
using Persistence.Repositories.File.Common.InvoiceFile;
using Persistence.Repositories.File.Common.OtherFile;
using Persistence.Repositories.File.Common.VideoFile;
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
        // System.Console.WriteLine(configuration.GetConnectionString("Default"));
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
        services.AddScoped<IApplicationUserClaimQueryRepository, ApplicationUserClaimQueryRepository>();
        services.AddScoped<IApplicationUserClaimCommandRepository, ApplicationUserClaimCommandRepository>();
        services.AddScoped<IEndpointQueryRepository, EndpointQueryRepository>();
        services.AddScoped<IEndpointCommandRepository, EndpointCommandRepository>();
        services.AddScoped<IMenuQueryRepository, MenuQueryRepository>();
        services.AddScoped<IMenuCommandRepository, MenuCommandRepository>();
        
        // File Repository
        services.AddScoped<IFileQueryRepository, FileQueryRepository>();
        services.AddScoped<IFileCommandRepository, FileCommandRepository>();
        services.AddScoped<IDocumentFileQueryRepository, DocumentFileQueryRepository>();
        services.AddScoped<IDocumentFileCommandRepository, DocumentFileCommandRepository>();
        services.AddScoped<IImageFileQueryRepository, ImageFileQueryRepository>();
        services.AddScoped<IImageFileCommandRepository, ImageFileCommandRepository>();
        services.AddScoped<IInvoiceFileQueryRepository, InvoiceFileQueryRepository>();
        services.AddScoped<IInvoiceFileCommandRepository, InvoiceFileCommandRepository>();
        services.AddScoped<IOtherFileQueryRepository, OtherFileQueryRepository>();
        services.AddScoped<IOtherFileCommandRepository, OtherFileCommandRepository>();
        services.AddScoped<IVideoFileQueryRepository, VideoFileQueryRepository>();
        services.AddScoped<IVideoFileCommandRepository, VideoFileCommandRepository>();

        //! Services
        services.AddScoped<ICustomAuthService, CustomAuthService>();
        services.AddScoped<IUserManagerService, UserManagerService>();
        services.AddScoped<IRoleManagerService, RoleManagerService>();
        services.AddScoped<IEndpointManagerService, EndpointManagerService>();
    }

}
