using Microsoft.AspNetCore.Mvc;
using Tienda.Application.DTOs;
using Tienda.Application.Services;

namespace Tienda.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _svc;
        public ProductsController(ProductService svc) => _svc = svc;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _svc.GetAllAsync());

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dto = await _svc.GetByIdAsync(id);
            return dto is null ? NotFound() : Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var id = await _svc.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductDto dto)
        {
            if (id != dto.Id) return BadRequest("El ID no coincide.");
            await _svc.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _svc.DeleteAsync(id);
            return NoContent();
        }

        [HttpPatch("{id:guid}/price")]
        public async Task<IActionResult> ConfigurePrice(Guid id, UpdatePriceDto dto)
        {
            if (id != dto.Id) return BadRequest("El ID no coincide.");
            await _svc.ConfigurePriceAsync(dto);
            return NoContent();
        }
    }
}
