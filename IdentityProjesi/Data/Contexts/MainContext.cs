using IdentityProjesi.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityProjesi.Data.Contexts {
    public class MainContext : IdentityDbContext<AppUser, AppRole, int> {

        public MainContext(DbContextOptions<MainContext> options) : base(options) {


        }
    }
}