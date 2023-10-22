using ApiCentralPark.Data.Repositorio;
using ApiCentralPark.Models;
using ApiCentralPark.Models.Comands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCentralPark.Controllers
{
    
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        public VeiculoRepositorio repositorio = new VeiculoRepositorio();
        public TarifaRepositorio tarifaRepositorio = new TarifaRepositorio();

        //////////////////////////////////////////////////////////////////////entrada
        [HttpPost]
        [Route("veiculo/entrada")]
        public IActionResult EntradaVeiculo([FromBody]CadastrarVeiculoCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(command.Placa))
                {
                    return BadRequest("Veiculo não encontrado");
                }
                if (repositorio.ObterPorPlaca(command.Placa) != null)
                {
                    return BadRequest("Esse veiculo já está estacionado");
                }
                var vaga = tarifaRepositorio.ObterValores();
                var espaco = repositorio.ObterTodosQueNaoSairam().Count();
                if (vaga.QuantidadeDeVagas <= espaco)
                {
                    return BadRequest("Estacionamento cheio");
                }

                var veiculo = repositorio.EntradaDeVeiculo(command.Placa);
                return Created("", veiculo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
        //////////////////////////////////////////////////////////////////////saida
        [HttpPut]
        [Route("veiculo/saida")]

        public IActionResult SaidaVeiculo([FromBody]SaidaVeiculoCommand command)
        {
            decimal valortarifa = 0;
            decimal valoradicional = 0;
            var tarifa = tarifaRepositorio.ObterValores();
            {
                valortarifa = tarifa.ValorTarifa;
                valoradicional = tarifa.ValorAdicional;
            }
            try
            {
                Veiculo veiculoInterno = repositorio.ObterPorPlaca(command.Placa);
                if (veiculoInterno == null)
                {
                    return NotFound("Veiculo não encontrado");
                }
                else
                {
                    repositorio.SaidaDeVeiculo(command.Placa, valortarifa, valoradicional);
                    return Ok(veiculoInterno);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
        //////////////////////////////////////////////////////////////////////obter todos
        [HttpGet]
        [Route("veiculo/obterTodos")]
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
        //////////////////////////////////////////////////////////////////////obter placa
        [HttpGet]
        [Route("veiculo/obterPorPlaca/{placa}")]
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
        //////////////////////////////////////////////////////////////////////obter id
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
        //////////////////////////////////////////////////////////////////////nãosairam
        [HttpGet]
        [Route("veiculo/obterosquenaosairam")]
        public IActionResult ObterTodosQueNaoSairam()
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
        //////////////////////////////////////////////////////////////////////já ssairam
        [HttpGet]
        [Route("veiculo/obterTodosQueSairam")]
        public IActionResult ObterTodosQueSairam()
        {
            try
            {
                var lista = repositorio.ObterTodosQueSairam();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
        //////////////////////////////////////////////////////////////////////excluir
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

