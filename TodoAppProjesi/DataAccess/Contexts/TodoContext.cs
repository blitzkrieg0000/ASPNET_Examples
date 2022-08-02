using DataAccess.Configurations;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts {

    public class TodoContext : DbContext {

        public DbSet<Work> Works { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options) {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        //     optionsBuilder.UseSqlServer("server=localhost; user=sa; database=TodoDb; password=DGH2022.");
        //     optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        //     base.OnConfiguring(optionsBuilder);
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
        }

    }

}