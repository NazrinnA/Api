using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp.Context.Repositories.Interfaces;
using WebApp.DTOS.Product;
using WebApp.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repo, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = repo;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            Product product = await _productRepository.Get(c => c.Id == id & c.IsActive & c.Category.IsActive, "Category");
            if (product is null) return NotFound();
            ProductGetDTO getProduct = _mapper.Map<ProductGetDTO>(product);
            return Ok(getProduct);
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            List<Product> products = await _productRepository.GetAll(c => c.IsActive & c.Category.IsActive, "Category");
            if (products.Count == 0) return NotFound();
            List<ProductGetDTO> getProducts = _mapper.Map<List<ProductGetDTO>>(products);
            return Ok(getProducts);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(ProductPostDTO product)
        {
            if (product is null) return BadRequest();

            Product newProduct = _mapper.Map<Product>(product);
            Category category = await _categoryRepository.Get(c => c.Id == product.CategoryId);
            newProduct.Category = category;
            await _productRepository.Create(newProduct);

            return Ok();
        } 


        [HttpPut("update")]
        public async Task<IActionResult> Update(ProductUpdateDTO product,int id)
        {
            if (product is null) return BadRequest();

            var exsistProduct = await _productRepository.Get(c => c.Id == id & c.IsActive & c.Category.IsActive);
            if (exsistProduct is null) return BadRequest();

            var category = await _categoryRepository.Get(c => c.Name == product.CategoryName & c.IsActive);
            if (category is null) return BadRequest();

            exsistProduct.Price=product.Price;
            exsistProduct.Name=product.Name;
            exsistProduct.Category=category;
            await _productRepository.Update(exsistProduct);

            return Ok();
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            Product exsistProduct = await _productRepository.Get(c => c.Id == id & c.IsActive & c.Category.IsActive);
            if (exsistProduct is null) return BadRequest();

            exsistProduct.IsActive = false;
            await _productRepository.Update(exsistProduct);

            return Ok();
        }

    }
}
