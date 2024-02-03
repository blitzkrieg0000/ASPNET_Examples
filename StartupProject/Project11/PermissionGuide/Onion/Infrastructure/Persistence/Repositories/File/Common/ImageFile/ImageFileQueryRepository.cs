using Application.Interfaces.Repository.File.Common.ImageFile;
using Persistence.Contexts;
using F = Domain.Entities.File.Common;

namespace Persistence.Repositories.File.Common.ImageFile;


public class ImageFileQueryRepository : QueryRepository<F::ImageFile>, IImageFileQueryRepository {
    public ImageFileQueryRepository(DefaultContext context) : base(context) {
    }
}
