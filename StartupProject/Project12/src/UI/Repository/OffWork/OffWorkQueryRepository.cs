using Microsoft.EntityFrameworkCore;
using UI.Abstraction.Repository.OffWork;
using UI.Contexts;
using UI.Repositories;
using W = UI.Entity.Concrete.Work;

namespace UI.Repository.OffWork;


public class OffWorkQueryRepository(DefaultContext context) : QueryRepository<W::OffWork>(context), IOffWorkQueryRepository {

    public async Task<List<W::OffWork>> ListOffWorkRelationalAsync(){
        return await GetQuery().Include(x=>x.Employee).ToListAsync();
    }

}