using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityProjesi.Data.Contexts {
    public class MainContext : IdentityDbContext {

        public MainContext(DbContextOptions<MainContext> options) : base(options) {
        }

        

    }
}