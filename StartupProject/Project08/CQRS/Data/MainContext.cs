using Microsoft.EntityFrameworkCore;

namespace CQRS.Data {

    public class MainContext : DbContext {

        public MainContext(DbContextOptions<MainContext> options) : base(options) {

        }

        public DbSet<Student> Students => this.Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Student>().HasData(new Student[]{
               new Student(){ Name="Burakhan", Age=300,Surname="Şamlı", Id=1},
               new Student(){ Name="Ahmet", Age=200,Surname="ABC", Id=2},
               new Student(){ Name="Nida", Age=100,Surname="ABC", Id=3}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}