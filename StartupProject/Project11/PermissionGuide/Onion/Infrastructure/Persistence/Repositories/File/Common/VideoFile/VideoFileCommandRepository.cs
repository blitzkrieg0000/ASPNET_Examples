using Application.Interfaces.Repository.File.Common.VideoFile;
using Persistence.Contexts;
using F = Domain.Entities.File.Common;

namespace Persistence.Repositories.File.Common.VideoFile;


public class VideoFileCommandRepository : CommandRepository<F::VideoFile>, IVideoFileCommandRepository {
    public VideoFileCommandRepository(DefaultContext context) : base(context) {
        
    }
}