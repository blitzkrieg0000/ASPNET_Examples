using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreProjesi.Data.Entities {
    public class Employee {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class PartTimeEmployee : Employee {
        public decimal DailyWage { get; set; }

    }

    public class FullTimeEmployee : Employee {
        public decimal HourlyWage { get; set; }

    }

}