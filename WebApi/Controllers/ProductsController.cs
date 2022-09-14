using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Interfaces;

namespace WebApi.Controllers {

    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase {

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = await _productRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var data = await _productRepository.GetByIdAsync(id);
            if (data == null) {
                return NotFound(id);
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product product) {
            var addedProduct = await _productRepository.CreateAsync(product);
            return Created("", addedProduct);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product) {
            var checkProduct = await _productRepository.GetByIdAsync(product.Id);
            if (checkProduct == null) {
                return NotFound(product.Id);
            }
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id) {
            var checkProduct = await _productRepository.GetByIdAsync(id);
            if (checkProduct == null) {
                return NotFound(id);
            }
            await _productRepository.RemoveAsync(id);
            return NoContent();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile formFile) {

            var newName = Guid.NewGuid() + "." + Path.GetExtension(formFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created("", formFile);

        }

        [HttpGet("[action]")]
        //[FromForm] string name, [FromHeader] string auth,
        public IActionResult Test([FromServices] IDummyRepository _dummyRepository) {
            // var authentication = HttpContext.Request.Headers["auth"];
            // var name2 = HttpContext.Request.Form["name"];
            return Ok(_dummyRepository.GetName());
        }
    }
}