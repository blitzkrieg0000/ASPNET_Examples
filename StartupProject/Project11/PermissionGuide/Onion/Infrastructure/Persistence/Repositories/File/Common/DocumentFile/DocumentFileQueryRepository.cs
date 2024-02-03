using Application.Interfaces.Repository.File.Common.DocumentFile;
using Persistence.Contexts;
using F = Domain.Entities.File.Common;

namespace Persistence.Repositories.File.Common.DocumentFile;


public class DocumentFileQueryRepository : QueryRepository<F::DocumentFile>, IDocumentFileQueryRepository {
    public DocumentFileQueryRepository(DefaultContext context) : base(context) {
    }
}
