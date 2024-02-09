using E = UI.Entity.Concrete.Employee;
namespace UI.Abstraction.Repository.Employee;

public interface IEmployeeQueryRepository : IQueryRepository<E::Employee> {

}
