using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp.Context.Repositories.Interfaces;
using WebApp.DTOS.Category;
using WebApp.Entities;


namespace WebApp.Controllers
{
	[Route("api/category")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryRepository _repo;
		private readonly IMapper _mapper;
        public CategoriesController(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet("get")]
		public async Task<IActionResult> Get(int id)
		{
			Category category = await _repo.Get(c=>c.Id==id & c.IsActive);
			if(category is null) return NotFound();

		    GetDTO getCategory=_mapper.Map<GetDTO>(category);

			return Ok(getCategory);
		}

		[HttpGet("get-all")]
		public async Task<IActionResult> GetAll()
		{
			List<Category> categories = await _repo.GetAll(c => c.IsActive);
			if (categories.Count == 0) return NotFound();

			List<GetDTO> getCategories = _mapper.Map<List<GetDTO>>(categories);

			return Ok();
		}

		[HttpPost("create")]
		public async Task<IActionResult> Create(PostDTO category)
		{
			if (category is null) return BadRequest();

			Category cat = _mapper.Map<Category>(category);

			await _repo.Create(cat);

			return Ok();
		}

		[HttpPut("update")]
		public async Task<IActionResult> Update(int id, UpdateDTO category)
		{
			if (category is null) return BadRequest();

			Category exsistCategory = await _repo.Get(c => c.Id == id);
			if (exsistCategory is null) return BadRequest();

			exsistCategory.Name = category.Name;
			await _repo.Update(exsistCategory);

			return Ok();
		}

		[HttpDelete("delete")]
		public async Task<IActionResult> Delete(int id)
		{
			Category exsistCategory = await _repo.Get(c => c.Id == id);
			if (exsistCategory is null) return BadRequest();

			exsistCategory.IsActive = false;
			await _repo.Update(exsistCategory);

			return Ok();
		}

	}
}
