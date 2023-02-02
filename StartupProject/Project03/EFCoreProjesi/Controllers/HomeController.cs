using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreProjesi.Data.Contexts;
using EFCoreProjesi.Data.Entities;
using EFCoreProjesi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProjesi.Controllers {
    public class HomeController : Controller {

        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;
        private readonly ISingletonService _singletonService;
        
        public HomeController(ITransientService transientService, IScopedService scopedService, ISingletonService singletonService) {
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
        }

        public IActionResult DependencyInjection() {
            ViewBag.Scoped = _scopedService.GuidId;
            ViewBag.Transient = _transientService.GuidId;
            ViewBag.Singleton = _singletonService.GuidId;
            
            return View("Index");
        }

        public IActionResult Add() {
            TennisContext context = new();

            //! ADD
            var entitiyEntry = context.Products.Add(new Data.Entities.Product {
                Name = "Telefon",
                Price = 3400
            });

            Product product = new() { Price = 4000 };
            context.Products.Add(product);

            return View("Index");
        }

        public IActionResult Update() {
            TennisContext context = new();

            //! UPDATE
            var updatedProduct = context.Products.Find(1);
            updatedProduct.Price = 4000;
            context.Products.Update(updatedProduct); //Updata kullanılmasa bile güncellenecek

            //update e bir nesne verildiğinde sanki ekliyormuş gibi günceller. Yani yeni bir nesne oluşturup ilgili alanları setlemezsek, db deki o alanlar null olarak geçer.
            var entitiyEntry2 = context.Products.Update(new Data.Entities.Product {
                Id = 1,
                Name = "Bilgisayar"
            });

            return View("Index");
        }

        public IActionResult Remove() {
            TennisContext context = new();

            //! DELETE
            var deletedProduct = context.Products.FirstOrDefault(x => x.Id == 1);
            context.Products.Remove(deletedProduct);

            return View("Index");
        }

        public IActionResult TPH() {
            TennisContext context = new();

            //! Table Per Hierarchy
            context.Employees.Add(new PartTimeEmployee {
                DailyWage = 400,
                FirstName = "part",
                LastName = "part"
            });

            context.Employees.Add(new PartTimeEmployee {
                DailyWage = 400,
                FirstName = "part2",
                LastName = "part2"
            });

            context.Employees.Add(new FullTimeEmployee {
                HourlyWage = 60,
                FirstName = "full",
                LastName = "full"
            });


            var parts = context.PartTimeEmployees.ToList();
            var parts2 = context.Employees.Where(x => x is PartTimeEmployee).ToList();
            context.SaveChanges();

            return View();
        }

        public IActionResult AddBlog() {
            BlogContext context = new();

            context.Add(new Blog {
                Title = "Blog-1",
                Url = "blitzkrieg-1"
            });

            context.Add(new Blog {
                Title = "Blog-2",
                Url = "blitzkrieg-2"
            });

            context.Add(new Blog {
                Title = "Blog-3",
                Url = "blitzkrieg-3"
            });

            context.Add(new Blog {
                Title = "Blog-4",
                Url = "blitzkrieg-4"
            });

            context.SaveChanges();
            return View("Index");
        }

        public IActionResult QueryableEnumerable() {
            BlogContext context = new();

            var list_results = context.Blogs.ToList();             //Tüm tabloyu çeker
            var enumerable_results = context.Blogs.AsEnumerable();
            var queryable_results = context.Blogs.AsQueryable();

            //! Queryable Sorgu .AsQueryable();
            // Database e gerekli şartlar ile gider gerekli veriyi alır.
            // Where sorgusunda normalde IQuerable bir obje döner.
            var results = queryable_results
                .Where(x => x.Title.Contains("Blog-1") || x.Title.Contains("Blog-2")) //Giden sorguda Where parametresi yok, As Enumerable olarak işaretlenmemişse Querable olarak çalışır.
                .AsEnumerable(); //Enumerable yapmak; Database ile olan işini bitirmek için kullanılır ya da .ToList() kullanılabilir. Ayrıca .ToList() Generic List e de çevirmiş olur.

            //! Enumerable sorgu .AsEnumerable()
            // Database den tüm verileri çekip server tarafında işlemeye yarar.
            // Çok fazla veri varsa yararlı değildir.
            var local_result = results.Where(x => x.Title == "Blog-1");
            foreach (var item in local_result) {
                System.Console.WriteLine(item.Title);
            }

            return View("Index");
        }

        public IActionResult Tracking() {
            BlogContext context = new();

            //! TrackingOn
            // var updateBlog = context.Blogs.SingleOrDefault(x => x.Id == 1);
            // updateBlog.Title="Güncellendi";
            // var updatadBlogState = context.Entry(updateBlog).State; //İlgili context in state i
            // context.SaveChanges();

            //! NoTracking
            var updateBlog = context.Blogs.AsNoTracking().SingleOrDefault(x => x.Id == 2); //.AsNoTracking(), Detached yapılmasını sağlar.
            updateBlog.Title = "Güncellendi";
            var updatadBlogState = context.Entry(updateBlog).State; //Tracking ile ilişkisini kestiğimiz için "context.Entry" den ulaşırız.
            context.SaveChanges();

            return View("Index");
        }

        public IActionResult LazyLoading() {
            BlogContext context = new();

            //! LazyLoading
            // Ekstra Paket Gereklidir ve database e bağlanırken optionsBuilder dan ".UseLazyLoadingProxies()" çağrılmalıdır.
            // Aynı zamanda Relationshipler "virtual" keyi ile işaretlenmelidir.
            var blogs = context.Blogs.ToList(); //Her sorguda database e gider.

            foreach (var blog in blogs) {
                Console.WriteLine($"{blog.Title} bloğu yorumları:");
                foreach (var comment in blog.Comments) {
                    Console.WriteLine($"\t{comment.Content}");
                }
            }
            return View("Index");
        }

        public IActionResult EagerLoading() {
            BlogContext context = new();
            
            //! EagerLoading:
            var blogs = context.Blogs.Include(x => x.Comments.Where(x => x.Content.Contains("Yorum1"))).ToList(); //Şartları belirtiriz ve tek seferde kayıtlar gelir.

            foreach (var blog in blogs) {
                Console.WriteLine($"{blog.Title} bloğu yorumları:");
                foreach (var comment in blog.Comments) {
                    Console.WriteLine($"\t{comment.Content}");
                }
            }
            return View("Index");
        }

        public IActionResult ExplicitLoading() {
            BlogContext context = new();

            //! ExplicitLoading
            // .Load() Fonksiyonu çağrıldığında gidip ilgili sorguya göre veriyi çeker.
            var blog = context.Blogs.SingleOrDefault(x => x.Id == 1);
            
            context.Entry(blog).Collection(x => x.Comments).Load();  //Gerekli kayıtları Load() çalıştırıldığında çeker.

            foreach (var item in blog.Comments) {
                Console.WriteLine(item.Content);
            }
            return View("Index");
        }


        public IActionResult Index() {
            return View("Index");
        }

    }
}