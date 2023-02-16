using System.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using jwtapp.front.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace jwtapp.front.Controllers
{
   [Authorize(Roles ="Admin , Member")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _client;

        public ProductController(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<IActionResult> List()
        {
            var token = User.Claims.FirstOrDefault(x=>x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _client.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                ("Bearer",token);
                var response = await client.GetAsync("https://localhost:7021/api/product");
                if (response.IsSuccessStatusCode)
                {
                    var jsondata = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<ProductListModel>(jsondata,new JsonSerializerOptions{
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    return View(result);
                }
            }
            return View();
                
            
        }
        public async Task<IActionResult> Remove(int id)
        {
            var token = User.Claims.FirstOrDefault(x=>x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _client.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                ("Bearer",token);
                 await client.DeleteAsync($"https://localhost:7021/api/product/{id}");
                
            }
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Create()
        {
                var token = User.Claims.FirstOrDefault(x=>x.Type == "accessToken")?.Value;
                if (token != null)
                {
                    var client = _client.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                    ("Bearer",token);
                    var response = await client.GetAsync("https://localhost:7021/api/category");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonData,new JsonSerializerOptions{
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                var model = new CreateProductModel()
                {
                    Categories = new SelectList(data,"Id","Definition")
                };
                return View(model);
                }
                               
            }
           
            return RedirectToAction("List");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductModel model)
        {
            var data = TempData["Categories"]?.ToString();
            if (data != null)
            {
                var categories = JsonSerializer.Deserialize<List<SelectListItem>>(data);
                model.Categories = new SelectList(categories,"Value","Text");
            }
            if (ModelState.IsValid)
            {
                var token = User.Claims.FirstOrDefault(x=>x.Type == "accessToken")?.Value;
                if (token != null)
                {
                    var client = _client.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                    ("Bearer",token);

                    var jsonData = JsonSerializer.Serialize(model);
                    var content = new StringContent(jsonData, Encoding.UTF8,"application/json");


                    var response = await client.PostAsync("https://localhost:7021/api/product",content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List");
                    }
                    ModelState.AddModelError("","Bir Hata Oluştu");
                }
                
            }
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var token = User.Claims.FirstOrDefault(x=>x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _client.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                ("Bearer",token);
                
                var responseCategory = await client.GetAsync("https://localhost:7021/api/category");
                if (responseCategory.IsSuccessStatusCode)
                {
                     var jsonData = await responseCategory.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonData,new JsonSerializerOptions{
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                var model = new CreateProductModel()
                {
                    Categories = new SelectList(data,"Id","Definition")
                };
                }
                
                var responseProduct = await client.GetAsync($"https://localhost:7021/api/product/{id}");
                if (responseProduct.IsSuccessStatusCode)
                {
                    var jsondata = await responseProduct.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<UpdateProductModel>(jsondata,new JsonSerializerOptions{
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    return View(result);  
                }
            }
            return View();
        }
    }
}