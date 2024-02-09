using UI.Abstraction.Repository.Employee;
using UI.Contexts;
using UI.Repositories;
using E = UI.Entity.Concrete.Employee;

namespace UI.Repository.Employee;


public class EmployeeCommandRepository : CommandRepository<E::Employee>, IEmployeeCommandRepository {
    public EmployeeCommandRepository(DefaultContext context) : base(context) {

    }
}
