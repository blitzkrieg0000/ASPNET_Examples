using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using WebProjesi.Filters;
using WebProjesi.Models;
#pragma warning disable IDE0090, IDE0060, IDE1006, IDE0051, IDE0044

namespace WebProjesi.Controllers {

    //[Route("[controller]/[action]")] //AttributeRoute
    public class HomeController : Controller {

        //[Route("Index")] //AttributeRoute
        public IActionResult Index() {

            //Customer customer = new(){FirstName = "BlitzKrieg", LastName="Burakhan", Age=27};
            //! Obje kullanarak ilgili "Index" View e veri gönderme
            var customers = CustomerContext.Customers;
            return View(customers); //Model veriyoruz. Verilen değer String olursa gidip o isimde view arar.

            //! Veri Taşıma [ViewBag, ViewData, TempData]
            // ViewBag.Name = "Burakhan";
            // ViewData["Name"] = "BlitzKrieg"; //Aynı zamanda ViewBag.Name değerini de değiştirir. Aynısıdır.
            // TempData["Name"] = "Burakhan2";  //Temp data diğerleri gibi çalışır tek farkı actionlar arası veri geçirebilirsiniz.

            //! Redirect To Another Action
            //return RedirectToAction("Index", "Product", new {@id=1}); //Başka bir controller içindeki Action u çağırma
            //return RedirectToAction("Admin", new { @id = 1 });

            //! Route
            // var values = RouteData.Values;
            // var id = int.Parse((string) values["id"]);
            //return View(customer);

        }

        public IActionResult Customers() {
            //! Static Data
            var customers = CustomerContext.Customers;
            return View(customers);
        }

        public IActionResult Admin(int id) {
            return View();
        }

        public IActionResult Create() {
            return View(new Customer());
        }

        [HttpPost]
        [ValidFirstName]
        public IActionResult Create(Customer customer) {
            //Model Binding Olmadan
            // var firstName = HttpContext.Request.Form["firstName"].ToString();
            // var lastName = HttpContext.Request.Form["lastName"].ToString();
            // var age = int.Parse(HttpContext.Request.Form["age"].ToString());

            //Validation
            ModelState.Remove("Id"); //Eklemede Id ye ihtiyacımız olmadığı için Id alanını kaldırıyoruz ki ModelState Hata vermesin.

            if (customer.FirstName == "Burakhan") {
                ModelState.AddModelError("", "İsim bu değer olamaz."); //Yeni Error eklenirse validation.IsValid i etkiler.
            }

            var control = ModelState.IsValid;

            var errors = ModelState.Values.SelectMany(
                item => item.Errors.Select(
                    item => item.ErrorMessage
                ));

            if (control) {
                var lastCustomer = CustomerContext.Last();
                customer.Id = 1;
                if (lastCustomer != null) {
                    customer.Id = 1 + lastCustomer.Id;
                }

                CustomerContext.Customers.Add(customer);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Remove(int id) {
            //var id = int.Parse(RouteData.Values["id"].ToString());
            var removedCustomer = CustomerContext.Customers.Find(item => item.Id == id);

            CustomerContext.Customers.Remove(removedCustomer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id) {
            //var id = int.Parse(RouteData.Values["id"].ToString());
            var updatedCostumer = CustomerContext.Customers.FirstOrDefault(item => item.Id == id);
            return View(updatedCostumer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer) {
            //var id = int.Parse(HttpContext.Request.Form["id"].ToString());
            var UpdatedCustomer = CustomerContext.Customers.FirstOrDefault(item => item.Id == customer.Id);

            //UpdatedCustomer.FirstName = HttpContext.Request.Form["firstName"].ToString();
            //UpdatedCustomer.LastName = HttpContext.Request.Form["lastName"].ToString();
            //UpdatedCustomer.Age = int.Parse(HttpContext.Request.Form["age"].ToString());

            UpdatedCustomer.FirstName = customer.LastName;
            UpdatedCustomer.LastName = customer.LastName;
            UpdatedCustomer.Age = customer.Age;

            return RedirectToAction("Index");
        }

        public IActionResult Status(int? code){
            return View();
        }

        public IActionResult Error(){
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");

            var logFileName = DateTime.Now.ToString();

            logFileName = logFileName.Replace(" ","_");
            logFileName = logFileName.Replace(":","-");
            logFileName = logFileName.Replace("/","-");
            logFileName += ".txt";

            var logFilePath = Path.Combine(logFolderPath, logFileName);

            DirectoryInfo directoryInfo = new DirectoryInfo(logFolderPath);

            if(!directoryInfo.Exists){
                directoryInfo.Create();
            }

            FileInfo fileInfo = new FileInfo(logFilePath);
            var writer = fileInfo.CreateText();Player

            writer.WriteLine("Hatanın Gerçekleştiği Yer:"+ exceptionHandlerPathFeature.Path);
            writer.WriteLine("Hata:"+ exceptionHandlerPathFeature.Error.Message);
            //writer.WriteLine("StackTrace:" + exceptionHandlerPathFeature.Error.StackTrace);

            writer.Close();
            return View();
        }

        public IActionResult Hata(){
            throw new System.Exception("Sistemsel hata oluştu!");
        }
    }
}