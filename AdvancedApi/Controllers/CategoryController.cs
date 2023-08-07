using AdvancedApi.Model;
using AdvancedApi.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        protected readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Category> GetAll() => _service.GetAll();

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Category> GetById([FromRoute] int id) => await _service.GetById(id);

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            _service.Add(category);
            return Ok(new { Message = "Category Successfully Create" });
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            _service.Update(category);
            return Ok(new { Message = "Category Successfully Updated" });
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id)
        {
            var category = _service.GetById(id);
            _service.ChangeStatus(category.Result);

            return Ok(new { Message = "Category Status Has Successfully Changed" });
        }
    }
}
