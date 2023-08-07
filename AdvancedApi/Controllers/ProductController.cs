using AdvancedApi.Model;
using AdvancedApi.Service.Classes;
using AdvancedApi.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Product> GetAll() => _service.GetAll();

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Product> GetById([FromRoute] int id) => await _service.GetById(id);

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            _service.Add(product);
            return Ok(new { Message = "Category Successfully Create" });
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            _service.Update(product);
            return Ok(new { Message = "Category Successfully Updated" });
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id)
        {
            var product = _service.GetById(id);
            _service.ChangeStatus(product.Result);

            return Ok(new { Message = "Category Status Has Successfully Changed" });
        }
    }
}
