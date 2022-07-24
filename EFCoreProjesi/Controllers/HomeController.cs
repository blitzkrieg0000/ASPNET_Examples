using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreProjesi.Data.Contexts;
using EFCoreProjesi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProjesi.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {

            //Contexts
            TennisContext context = new();
            BlogContext blogContext = new();

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


            // blogContext.Add(new Blog{
            //     Title = "Blog-1",
            //     Url = "blitzkrieg-1"
            // });

            // blogContext.Add(new Blog{
            //     Title = "Blog-2",
            //     Url = "blitzkrieg-2"
            // });

            // blogContext.Add(new Blog{
            //     Title = "Blog-3",
            //     Url = "blitzkrieg-3"
            // });

            // blogContext.Add(new Blog{
            //     Title = "Blog-4",
            //     Url = "blitzkrieg-4"
            // });

            // context.SaveChanges();
            // blogContext.SaveChanges();



            //! Queryable vs Enumerable
            // var enum_results = blogContext.Blogs.AsEnumerable();
            // var query_results = blogContext.Blogs.AsQueryable();

            // //* Queryable Sorgu .AsQueryable();
            // // Database e gerekli şartlar ile gider gerekli veriyi alır.
            // var results = query_results
            // .Where(x => x.Title.Contains("Blog-1") || x.Title.Contains("Blog-2"))
            // .AsEnumerable();
            // //.ToList();

            // //* Enumerable sorgu .AsEnumerable()
            // // Database den tüm verileri çekip server tarafında işlemeye yarar.
            // // Çok fazla veri varsa yararlı değildir.
            // var local_result = results.Where(x => x.Title=="Blog-1");


            // foreach (var item in local_result) {
            //     System.Console.WriteLine(item.Title);
            // }


            //! TRACKING vs NoTracking
            //* Tracking
            // var updateBlog = blogContext.Blogs.SingleOrDefault(x => x.Id == 1);
            // updateBlog.Title="Güncellendi";
            // var updatadBlogState = blogContext.Entry(updateBlog).State;
            // context.SaveChanges();

            //* NoTracking
            // var updateBlog = blogContext.Blogs.AsNoTracking().SingleOrDefault(x => x.Id == 2);
            // updateBlog.Title="Güncellendi";
            // var updatadBlogState = blogContext.Entry(updateBlog).State;
            // context.SaveChanges();

            //! LOAD DATA (Lazy, Eager, Explicit)
            



            return View();
        }

    }
}