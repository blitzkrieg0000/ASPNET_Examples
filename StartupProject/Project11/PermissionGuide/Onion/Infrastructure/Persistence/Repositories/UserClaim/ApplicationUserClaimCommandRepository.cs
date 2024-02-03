using Application.Interfaces.Repository.UserClaim;
using Persistence.Contexts;

namespace Persistence.Repositories.UserClaim;


public class ApplicationUserClaimCommandRepository : CommandRepository<Domain.Entities.Auth.ApplicationUserClaim>, IApplicationUserClaimCommandRepository {
    public ApplicationUserClaimCommandRepository(DefaultContext context) : base(context) {
    }
}
