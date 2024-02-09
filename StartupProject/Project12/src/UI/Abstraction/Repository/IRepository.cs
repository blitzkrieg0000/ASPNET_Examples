using Microsoft.EntityFrameworkCore;
using UI.Entity;

namespace UI.Abstraction.Repository;


public interface IRepository<T> where T : BaseEntity {

    DbSet<T> Table { get; }

}
