using Application.Interfaces.Repository.File.Common.InvoiceFile;
using Persistence.Contexts;
using F = Domain.Entities.File.Common;

namespace Persistence.Repositories.File.Common.InvoiceFile;


public class InvoiceFileCommandRepository : CommandRepository<F::InvoiceFile>, IInvoiceFileCommandRepository {
    public InvoiceFileCommandRepository(DefaultContext context) : base(context) {
    }
}
