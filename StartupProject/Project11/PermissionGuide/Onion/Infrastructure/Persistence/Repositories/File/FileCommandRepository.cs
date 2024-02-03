using Application.Interfaces.Repository.File;
using Persistence.Contexts;
using F = Domain.Entities.File;

namespace Persistence.Repositories.File;


public class FileCommandRepository : CommandRepository<F::File>, IFileCommandRepository {
    public FileCommandRepository(DefaultContext context) : base(context) {

    }
}
