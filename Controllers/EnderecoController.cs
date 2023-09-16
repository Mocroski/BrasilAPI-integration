using IntegraBrasilAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IntegraBrasilAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class EnderecoController : ControllerBase
    {
        public readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet("buscar/{cep}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> BuscarEndereco([FromRoute] string cep)
        {
            var response = await _enderecoService.BuscarEndereco(cep);
            if(response.StatusCode == HttpStatusCode.OK) {
                return Ok(response.Data);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.Error);
            }
        }
    }
}
