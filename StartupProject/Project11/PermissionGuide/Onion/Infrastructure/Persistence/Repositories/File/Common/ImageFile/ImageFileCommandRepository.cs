using Application.Interfaces.Repository.File.Common.ImageFile;
using Persistence.Contexts;
using F = Domain.Entities.File.Common;

namespace Persistence.Repositories.File.Common.ImageFile;


public class ImageFileCommandRepository : CommandRepository<F::ImageFile>, IImageFileCommandRepository {
    public ImageFileCommandRepository(DefaultContext context) : base(context) {
    }
}
