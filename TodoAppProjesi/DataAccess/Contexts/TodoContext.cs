using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts {

    public class TodoContext : DbContext {

        public TodoContext(DbContextOptions<TodoContext> options) : base(options) {


        }

        public DbSet<Work> Works { get; set; }
    }
}