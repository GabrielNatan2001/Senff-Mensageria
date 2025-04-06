using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenffMensageria.Application.UseCase.Aluno;
using Shared.DTO;

namespace SenffMensageria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;

        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(AlunoDto request)
        {
            await _service.Adicionar(request);

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, AlunoDto request)
        {
            await _service.Atualizar(id, request);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var result = await _service.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _service.Remover(id);

            return NoContent();
        }
    }
}
