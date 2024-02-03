using F = Domain.Entities.File.Common;

namespace Application.Interfaces.Repository.File.Common.InvoiceFile;


public interface IInvoiceFileCommandRepository : ICommandRepository<F::InvoiceFile> {

}
