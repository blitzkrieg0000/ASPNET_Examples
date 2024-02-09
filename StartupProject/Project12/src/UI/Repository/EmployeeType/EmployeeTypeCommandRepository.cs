using UI.Abstraction.Repository.EmployeeType;
using UI.Contexts;
using UI.Repositories;
using E=UI.Entity.Concrete.Employee;

namespace UI.Repository.EmployeeType;


public class EmployeeTypeCommandRepository : CommandRepository<E::EmployeeType>, IEmployeeTypeCommandRepository {
    public EmployeeTypeCommandRepository(DefaultContext context) : base(context) {

    }
}
