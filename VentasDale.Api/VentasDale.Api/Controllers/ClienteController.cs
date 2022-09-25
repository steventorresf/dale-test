using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasDale.Core.Interfaces;
using VentasDale.Domain.Dto;

namespace VentasDale.Api.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service= service;
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

        [HttpGet("by-cedula/{cedula}")]
        public async Task<IActionResult> GetByCedula(string cedula)
        {
            var response = await _service.GetByCedula(cedula);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] ClienteRequestDto request)
        {
            var response = await _service.Save(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClienteRequestDto request)
        {
            var response = await _service.Update(request);
            return Ok(response);
        }
    }
}
