using Application.Interfaces.Repository.File.Common.OtherFile;
using Persistence.Contexts;
using F = Domain.Entities.File.Common;

namespace Persistence.Repositories.File.Common.OtherFile;


public class OtherFileCommandRepository : CommandRepository<F::OtherFile>, IOtherFileCommandRepository {
    public OtherFileCommandRepository(DefaultContext context) : base(context) {
        
    }
}
