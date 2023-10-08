using Microsoft.AspNetCore.Mvc;
using WebApp.Context.Repositories.Interfaces;
using WebApp.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryRepository _repo;
		public CategoryController(ICategoryRepository repo)
		{
			_repo = repo;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			Category category = await _repo.GetById(c=>c.Id==id);
			if(category is null) return NotFound();
			return Ok(category);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			List<Category> categories=await _repo.GetAll();
			if(categories.Count==0) return NotFound();
			return Ok(categories);
		}

		[HttpPost]
		public async Task<IActionResult> Create(Category category)
		{
			if(category is null) return BadRequest();
			await _repo.Create(category);
			return Ok();
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> Update(Category category)
		{
			if (category is null) return BadRequest();
			await _repo.Update(category);
			return Ok();
		}
		[HttpPost("{id}")]
		public async Task<IActionResult> Delete(Category category)
		{
			if (category is null) return BadRequest();
			await _repo.Update(category);
			return Ok();
		}

	}
}
