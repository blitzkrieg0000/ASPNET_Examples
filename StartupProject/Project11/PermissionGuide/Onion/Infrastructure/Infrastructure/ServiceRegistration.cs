using Application.Interfaces.Service.Configurations;
using Application.Interfaces.Service.Hash;
using Application.Interfaces.Service.Mail;
using Application.Interfaces.Service.Redis;
using Application.Interfaces.Service.Storage;
using Application.Interfaces.Service.Token;
using Application.Interfaces.Service.ViewToString;
using Infrastructure.Enums;
using Infrastructure.Services.Configurations;
using Infrastructure.Services.Hash;
using Infrastructure.Services.Mail;
using Infrastructure.Services.Redis;
using Infrastructure.Services.Storage;
using Infrastructure.Services.Storage.Local;
using Infrastructure.Services.Token.JWT;
using Infrastructure.Services.ViewToString;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Infrastructure;


public static class ServiceRegistration {

    public static void AddInfrastructureServices(this IServiceCollection service, IConnectionMultiplexer multiplexer) {
        service.AddScoped<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
        service.AddScoped<IStorageService, StorageService>();
        service.AddScoped<IHashService, HashService>();
        service.AddScoped<IMailService, MailService>();
        service.AddScoped<IViewRenderService, ViewRenderService>();
        service.AddScoped<IApplicationService, ApplicationService>();
        service.AddScoped<IRedisCacheService, RedisCacheService>();

        // RedisConnection: IConnectionMultiplexer service
        service.AddSingleton(multiplexer);
    }


    public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType) {
        switch (storageType) {
            case StorageType.Local:
                serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
            default:
                serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
        }
    }

}
