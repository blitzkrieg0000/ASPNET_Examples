using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreProjesi.Data.Configurations;
using EFCoreProjesi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProjesi.Data.Contexts {
    public class BlogContext : DbContext {

        //Entities
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //Connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("server=localhost; user=sa; database=TennisEfCore; password=DGH2022.");
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}