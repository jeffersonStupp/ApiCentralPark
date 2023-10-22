using ApiCentralPark.Data.Repositorio;
using ApiCentralPark.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCentralPark.Controllers
{
    
    [ApiController]
    public class TarifaController : ControllerBase
    {
        public TarifaRepositorio repositorio = new TarifaRepositorio();

        [HttpPut]
        [Route("tarifas/editar")]
        public IActionResult EditarTarifas([FromBody] Tarifa tarifa)
        {
            try
            {
                repositorio.Editar(tarifa);
                return Ok(tarifa);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
        [HttpGet]
        [Route("tarifas/obterValores")]
        public IActionResult ObterValores()
        {
            try
            {
                var tarifa = repositorio.ObterValores();
                {
                    return Ok(tarifa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
    }
}
