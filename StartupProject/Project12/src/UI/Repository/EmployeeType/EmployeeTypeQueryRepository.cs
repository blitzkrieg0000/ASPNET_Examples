using E=UI.Entity.Concrete.Employee;
using UI.Repositories;
using UI.Abstraction.Repository.EmployeeType;
using UI.Contexts;

namespace UI.Repository.EmployeeType;


public class EmployeeTypeQueryRepository(DefaultContext context) : QueryRepository<E::EmployeeType>(context), IEmployeeTypeQueryRepository {

}
