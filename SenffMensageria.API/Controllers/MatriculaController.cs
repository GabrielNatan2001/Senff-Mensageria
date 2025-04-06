using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenffMensageria.Application.UseCase.Matricula;
using Shared.DTO;

namespace SenffMensageria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _service;

        public MatriculaController(IMatriculaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Matricular(MatriculaDto request)
        {
            await _service.Adicionar(request);
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }
    }
}
