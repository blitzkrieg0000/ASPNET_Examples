using Application.Interfaces.Repository.File.Common.DocumentFile;
using Persistence.Contexts;
using F = Domain.Entities.File.Common;

namespace Persistence.Repositories.File.Common.DocumentFile;


public class DocumentFileCommandRepository : CommandRepository<F::DocumentFile>, IDocumentFileCommandRepository {
    public DocumentFileCommandRepository(DefaultContext context) : base(context) {
    }
}
