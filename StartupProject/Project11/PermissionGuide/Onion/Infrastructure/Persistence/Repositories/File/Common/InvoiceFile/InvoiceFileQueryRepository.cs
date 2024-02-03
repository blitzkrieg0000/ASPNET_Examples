using Application.Interfaces.Repository.File.Common.InvoiceFile;
using Persistence.Contexts;
using F = Domain.Entities.File.Common;

namespace Persistence.Repositories.File.Common.InvoiceFile;


public class InvoiceFileQueryRepository : QueryRepository<F::InvoiceFile>, IInvoiceFileQueryRepository {
    public InvoiceFileQueryRepository(DefaultContext context) : base(context) {
    }
}
