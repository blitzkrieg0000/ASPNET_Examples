using System.Collections.Generic;

namespace WebProjesi.Models {

    public static class CustomerContext{
    
        public static List<Customer> Customers = new(){
            new Customer(){Id=1, FirstName= "Burakhan", LastName="Şamlı", Age=23},
            new Customer(){Id=2, FirstName= "Blitz", LastName="Krieg", Age=25}
        };

        public static Customer Last(){

            Customer cust = null;
            if (!(Customers.Count > 0)){
                cust = Customers[Customers.Count-1];
            }
            return cust;
        }

    }

}