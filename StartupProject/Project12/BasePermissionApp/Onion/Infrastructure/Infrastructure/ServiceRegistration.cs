using Application.Interfaces.Service.Hash;
using Infrastructure.Services.Hash;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;


public static class ServiceRegistration {

    public static void AddInfrastructureServices(this IServiceCollection service) {
        service.AddScoped<IHashService, HashService>();

    }


}
