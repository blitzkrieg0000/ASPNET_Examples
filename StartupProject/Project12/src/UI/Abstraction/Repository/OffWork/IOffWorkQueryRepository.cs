using W = UI.Entity.Concrete.Work;

namespace UI.Abstraction.Repository.OffWork;


public interface IOffWorkQueryRepository : IQueryRepository<W::OffWork> {

    /**
        <summary>
            Retrieves a list of OffWork entities including related Employee entities asynchronously.
        </summary>
        <returns>A task that represents the asynchronous operation. The task result contains a list of OffWork entities with related Employee entities.</returns>
    */
    Task<List<W::OffWork>> ListOffWorkRelationalAsync();

}
