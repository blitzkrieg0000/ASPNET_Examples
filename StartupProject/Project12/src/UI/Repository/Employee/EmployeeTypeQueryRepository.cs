using E = UI.Entity.Concrete.Employee;
using UI.Repositories;
using UI.Abstraction.Repository.Employee;
using UI.Contexts;

namespace UI.Repository.Employee;


public class EmployeeQueryRepository(DefaultContext context) : QueryRepository<E::Employee>(context), IEmployeeQueryRepository {

}
