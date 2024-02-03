using Application.Interfaces.Repository.File;
using Persistence.Contexts;
using F = Domain.Entities.File;

namespace Persistence.Repositories.File;


public class FileQueryRepository : QueryRepository<F::File>, IFileQueryRepository {
    public FileQueryRepository(DefaultContext context) : base(context) {
    
    }
}
