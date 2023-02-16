using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using jwtapp.front.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace jwtapp.front.Controllers {

    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller {
        private readonly IHttpClientFactory _client;

        public CategoryController(IHttpClientFactory client) {
            _client = client;
        }

        public async Task<IActionResult> List() {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null) {
                var client = _client.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                ("Bearer", token);
                var response = await client.GetAsync("https://localhost:7021/api/category");
                if (response.IsSuccessStatusCode) {
                    var jsondata = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<CategoryListModel>(jsondata, new JsonSerializerOptions {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    return View(result);
                }
            }
            return View();


        }
        public async Task<IActionResult> Remove(int id) {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null) {
                var client = _client.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                ("Bearer", token);
                var response = await client.DeleteAsync($"https://localhost:7021/api/categories/{id}");

            }
            return RedirectToAction("List");
        }
        public IActionResult Create() {
            return View(new CreateCategoryModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryModel model) {
            if (ModelState.IsValid) {
                var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;

                if (token != null) {
                    var client = _client.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                   ("Bearer", token);
                    var jsonData = JsonSerializer.Serialize(model);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://localhost:7021/api/categories/", content);
                    if (response.IsSuccessStatusCode) {
                        return RedirectToAction("List");
                    } else {
                        ModelState.AddModelError("", "Bir Hata Oluştu");
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Update(int id) {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null) {
                var client = _client.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                ("Bearer", token);
                var response = await client.GetAsync($"https://localhost:7021/api/category/{id}");
                if (response.IsSuccessStatusCode) {
                    var jsondata = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<CategoryListModel>(jsondata, new JsonSerializerOptions {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    return View(result);
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryListModel model) {
            if (ModelState.IsValid) {
                var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;

                if (token != null) {
                    var client = _client.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                   ("Bearer", token);
                    var jsonData = JsonSerializer.Serialize(model);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync("https://localhost:7021/api/categories/", content);
                    if (response.IsSuccessStatusCode) {
                        return RedirectToAction("List");
                    } else {
                        ModelState.AddModelError("", "Bir Hata Oluştu");
                    }
                }
            }
            return View(model);
        }

    }
}