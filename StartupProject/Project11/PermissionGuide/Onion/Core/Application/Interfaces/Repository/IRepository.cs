using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Repository;


public interface IRepository<T> where T : BaseEntity {

    DbSet<T> Table { get; }

}
