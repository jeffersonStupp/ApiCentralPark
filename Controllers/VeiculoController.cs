using ApiCentralPark.Database.Repositorio;
using ApiCentralPark.Models;
using ApiCentralPark.Models.Comands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiCentralPark.Controllers
{
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        public VeiculoRepositorio repositorio = new VeiculoRepositorio();






        [HttpGet]
        [Route("veiculo/listar")]
        public IActionResult ObterTodosVeiculos()
        {
            try
            {
                var lista = repositorio.ObterTodosVeiculos();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");

            }
        }

        [HttpPost]
        [Route("veiculo/entrada")]
        public IActionResult EntradaVeiculo([FromBody] RequisitarEntradaComand cmd)
        {
            try
            {
                if (cmd == null)
                {
                    return BadRequest("Não encontrado");
                }
                var veiculo = repositorio.EntradaDeVeiculo(cmd.Placa);
                return Created("", veiculo);

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");

            }
        }
        [HttpPut]
        [Route("veiculo/saida")]
        public IActionResult SaidaVeiculo(Veiculo veiculo)
        {
            try
            {
                Veiculo veiculosaindo = repositorio.ObterPorPlaca(veiculo.Placa);
                if (veiculosaindo == null)
                {
                    return NotFound("Veiculo não encontrado");
                }
                else
                {

                    veiculosaindo.HoraSaida = DateTime.Now;


                    repositorio.SaidaDeVeiculo(veiculosaindo);
                    return Ok(veiculosaindo);

                }



            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");

            }

        }
        

        [HttpGet]
        [Route("veiculo/obterporplaca/{placa}")]
        public IActionResult ObterPorPlaca(string placa)
        {
            try
            {
                var veiculo = repositorio.ObterPorPlaca(placa);
                if (veiculo == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(veiculo);
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");

            }
        }

        [HttpGet]
        [Route("veiculo/obterosquenaosairam")]
        public IActionResult ObterTodosQueNaoSairam( )
        {
            try
            {
                var lista = repositorio.ObterTodosQueNaoSairam();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");

            }
        }
        [HttpGet]
        [Route("veiculo/obterosquejasairam")]
        public IActionResult ObterTodosQuejaSairam()
        {
            try
            {
                var lista = repositorio.ObterTodosQuejaSairam();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");

            }
        }
        [HttpGet]
        [Route("veiculo/obterporid/{id}")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var veiculo = repositorio.ObterPorId(id);
                if (veiculo == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(veiculo);
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");

            }
        }

        [HttpDelete]
        [Route("veiculo/excluir/{id}")]
        
        public IActionResult Excluir(int id)
        {
            try
            {
                Veiculo veiculo = repositorio.ObterPorId(id);
                if (veiculo == null)
                {
                    return NotFound("Veiculo não encontrado");
                }

                repositorio.Exluir(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }


    }
}
