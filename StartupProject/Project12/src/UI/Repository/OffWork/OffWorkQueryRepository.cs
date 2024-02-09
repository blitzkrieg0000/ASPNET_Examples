using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Abstraction.Repository;
using UI.Abstraction.Repository.OffWork;
using UI.Contexts;
using UI.Repositories;
using W = UI.Entity.Concrete.Work;


namespace UI.Repository.OffWork;

public class OffWorkQueryRepository(DefaultContext context) : QueryRepository<W::OffWork>(context), IOffWorkQueryRepository {

}