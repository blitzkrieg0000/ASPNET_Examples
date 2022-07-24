using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreProjesi.Data.Contexts;
using EFCoreProjesi.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreProjesi.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {

            TennisContext context = new();

            //! ADD
            // var entitiyEntry = context.Products.Add(new Data.Entities.Product{
            //     Name = "Telefon",
            //     Price = 3400
            // });

            // Product product = new() { Price = 4000 };
            // context.Products.Add(product);


            //! UPDATE
            // var updatedProduct = context.Products.Find(1);
            // updatedProduct.Price  = 4000;
            // context.Products.Update(updatedProduct); //Updata kullanılmasa bile güncellenecek

            //update e bir nesne verildiğinde sanki ekliyormuş gibi günceller. Yani yeni bir nesne oluşturup ilgili alanları setlemezsek, db deki o alanlar null olarak geçer.
            // var entitiyEntry2 = context.Products.Update(new Data.Entities.Product{
            //     Id=1,
            //     Name= "Bilgisayar"
            // });


            //! DELETE
            // var deletedProduct = context.Products.FirstOrDefault(x => x.Id == 1);
            // context.Products.Remove(deletedProduct);


            //! Table Per Hierarchy
            // context.Employees.Add(new PartTimeEmployee{
            //     DailyWage=400,
            //     FirstName="part",
            //     LastName="part"
            // });

            // context.Employees.Add(new PartTimeEmployee{
            //     DailyWage=400,
            //     FirstName="part2",
            //     LastName="part2"
            // });

            // context.Employees.Add(new FullTimeEmployee{
            //     HourlyWage=60,
            //     FirstName="full",
            //     LastName="full"
            // });
            

            // var parts = context.PartTimeEmployees.ToList();
            // var parts2 = context.Employees.Where(x=>x is PartTimeEmployee).ToList();


            context.SaveChanges();
            return View();
        }

    }
}