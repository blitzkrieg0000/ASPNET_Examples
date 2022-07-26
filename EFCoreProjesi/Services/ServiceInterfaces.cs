using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreProjesi.Services {

    public interface IServiceBase {
        string GuidId { get; }
    }

    public interface ITransientService : IServiceBase {

    }

    public interface IScopedService : IServiceBase {

    }

    public interface ISingletonService : IServiceBase {

    }

}