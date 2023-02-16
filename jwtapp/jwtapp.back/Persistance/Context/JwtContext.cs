using System.Reflection;
using jwtapp.back.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace jwtapp.back.Persistance.Context
{
    public class JwtContext : DbContext
    {
         public JwtContext(DbContextOptions<JwtContext> options) : base(options)
         {
            
         }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public DbSet<AppRole>? AppRoles { get; set; }
        public DbSet<AppUser>? AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}