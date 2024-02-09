using UI.Abstraction.Repository.OffWork;
using UI.Contexts;
using UI.Repositories;
using W = UI.Entity.Concrete.Work;
namespace UI.Repository.OffWork;


public class OffWorkCommandRepository(DefaultContext context) : CommandRepository<W::OffWork>(context), IOffWorkCommandRepository {
}
