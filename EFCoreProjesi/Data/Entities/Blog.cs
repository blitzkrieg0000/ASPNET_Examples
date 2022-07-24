using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreProjesi.Data.Entities {
    public class Blog {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        //! LazyLoading: virtual
        public  List<Comment> Comments { get; set; }
    }
}