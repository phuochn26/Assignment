using System.Collections.Generic;
using EF2.Models;
using EF2.Models.DTO;
using EF2.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public List<Product> List()
        {
            return _productService.GetProducts();
        }
        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _productService.GetProductById(id);
        }
        [HttpPost]
        public List<Product> Create(ProductDTO product)
        {
            _productService.CreateProduct(product);
            return _productService.GetProducts();
        }
        [HttpPut("{id}")]
        public List<Product> Update(ProductDTO product,int id)
        {
            _productService.UpdateProduct(product, id);
            return _productService.GetProducts();
        }
        [HttpDelete("{id}")]
        public List<Product> Delete(int id)
        {
            _productService.DeleteProduct(id);
            return _productService.GetProducts();
        }
    }
}
