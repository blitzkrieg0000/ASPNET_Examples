using Application.Interfaces.Repository.File.Common.VideoFile;
using Persistence.Contexts;
using F = Domain.Entities.File.Common;

namespace Persistence.Repositories.File.Common.VideoFile;


public class VideoFileQueryRepository : QueryRepository<F::VideoFile>, IVideoFileQueryRepository {
    public VideoFileQueryRepository(DefaultContext context) : base(context) {
    
    }
}
