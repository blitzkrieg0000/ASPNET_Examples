using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ResponseObjects {
    public class CustomValidationError {

        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }

    }
}