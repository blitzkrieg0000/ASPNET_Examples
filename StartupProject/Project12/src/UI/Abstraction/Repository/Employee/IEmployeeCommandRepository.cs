using E = UI.Entity.Concrete.Employee;
namespace UI.Abstraction.Repository.Employee;

public interface IEmployeeCommandRepository : ICommandRepository<E::Employee> {

}
