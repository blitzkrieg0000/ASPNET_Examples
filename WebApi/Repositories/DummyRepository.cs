using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;

namespace WebApi.Repositories {
    public class DummyRepository : IDummyRepository {
        public string GetName() {
            return "Blitzkrieg";
        }
    }
}