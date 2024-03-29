using Microsoft.Extensions.Configuration;

namespace Persistence.Configurations;


static class Configuration {
    public static string ConnectionString {
        get {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/UI"));
            
            try {
                //? "appsettings.Development.json" CI/CD esnasında silinmelidir ki hassas veriler sunucuda dahi tutulmasın.
                configurationManager.AddJsonFile("appsettings.Development.json");
            } catch {
                configurationManager.AddJsonFile("appsettings.Production.json");
            }

            return configurationManager.GetConnectionString("Default");
        }
    }
}

