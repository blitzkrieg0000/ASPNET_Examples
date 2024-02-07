using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;


public static class ServiceRegistration {

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {

        // HttpContext'e DI ile ulaşabilmek için gerekli
        services.AddHttpContextAccessor();
        // System.Console.WriteLine(configuration.GetConnectionString("Default"));
        // DBContext
        // services.AddDbContext<DefaultContext>(opt => {
        //     opt.UseNpgsql(configuration.GetConnectionString("Default"));
        //     opt.LogTo(Console.WriteLine, LogLevel.Information);
        // });

    }

}
