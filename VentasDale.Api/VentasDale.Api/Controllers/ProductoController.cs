using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasDale.Core.Interfaces;
using VentasDale.Domain.Dto;

namespace VentasDale.Api.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] ProductoRequestDto request)
        {
            var response = await _service.Save(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductoRequestDto request)
        {
            var response = await _service.Update(request);
            return Ok(response);
        }
    }
}
