using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.Configurations;
using Persistence.Contexts;


namespace Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DefaultContext> {

    public DefaultContext CreateDbContext(string[] args) {

        DbContextOptionsBuilder<DefaultContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);

        return new(dbContextOptionsBuilder.Options);
    }

}
