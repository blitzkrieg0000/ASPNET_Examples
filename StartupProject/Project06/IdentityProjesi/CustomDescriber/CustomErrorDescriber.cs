using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityProjesi.CustomDescriber {
    public class CustomErrorDescriber : IdentityErrorDescriber {
        public override IdentityError PasswordTooShort(int length) {
            return new() {
                Code = "PasswordTooShort",
                Description = $"Parola en az {length} karakter olmalıdır."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric() {
            return new() {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parola en az bir alphanümerik (A-Z, a-z, 0-9) karakter içermelidir."
            };
        }

        public override IdentityError DuplicateUserName(string userName) {
            return new() {
                Code = "DuplicateUserName",
                Description = $"{userName} zaten alınmış."
            };
        }
    }
}