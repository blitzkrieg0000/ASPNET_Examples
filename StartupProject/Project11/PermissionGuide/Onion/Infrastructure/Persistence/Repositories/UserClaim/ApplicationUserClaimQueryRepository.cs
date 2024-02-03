using Application.Interfaces.Repository.UserClaim;
using Persistence.Contexts;

namespace Persistence.Repositories.UserClaim;

public class ApplicationUserClaimQueryRepository : QueryRepository<Domain.Entities.Auth.ApplicationUserClaim>, IApplicationUserClaimQueryRepository {
    public ApplicationUserClaimQueryRepository(DefaultContext context) : base(context) {
    
    }
}
