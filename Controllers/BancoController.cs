using IntegraBrasilAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IntegraBrasilAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BancoController : ControllerBase
    {
        public readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        [HttpGet("busca/todos")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> BuscarBancoList()
        {
            var response = await _bancoService.GetBancoAsync();
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.Data);
            } else
            {
                return StatusCode((int)response.StatusCode, response.Error);
            }
        }

        [HttpGet("busca/{codigoBanco}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Buscar([RegularExpression("^[0-9]*$")] string codigoBanco)
        {
            var response = await _bancoService.GetBancoByIdAsync(codigoBanco);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.Data);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.Error);
            }
        }
    }
}
