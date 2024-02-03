using Application.Interfaces.Repository.File.Common.OtherFile;
using Persistence.Contexts;
using F = Domain.Entities.File.Common;

namespace Persistence.Repositories.File.Common.OtherFile;

public class OtherFileQueryRepository : QueryRepository<F::OtherFile>, IOtherFileQueryRepository {
    public OtherFileQueryRepository(DefaultContext context) : base(context) {
        
    }
}
