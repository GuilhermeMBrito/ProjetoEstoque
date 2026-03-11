using DBServices.ServicesClass.DTO;
using DBServices.ServicesClass.Services;
using Microsoft.AspNetCore.Mvc;
using ProjetoEstoqueAPI.Class.Mapper;
using ProjetoEstoqueAPI.Controllers.ProdutoParametros;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEstoqueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger )
        {
            _logger = logger;
        }
        [HttpGet("BuscarUmProduto")]
        public async Task<IActionResult> BuscarUmProduto([FromQuery] int id)
        {
            try
            {
                ProdutoDTO produto = new ProdutoDTO();
                ProdutosHandler handler = new ProdutosHandler();
                produto = await handler.BuscarUmProdutoAsync(id);
                return Ok(produto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("BuscarProdutos")]
        public async Task<IActionResult> BuscarProdutos([FromBody] ProdutoBuscaParametro produto)
        {
            try
            {
                ProdutoMapper mapper = new ProdutoMapper();

                ProdutoDTO produtoDto = mapper.BuscaMapper(produto);

                ProdutosHandler handler = new ProdutosHandler();
                IList<ProdutoDTO> produtos = await handler.BuscarProdutosAsync(produtoDto);
                if (produtos.Count > 0)
                {
                    return Ok(produtos);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost("InserirProduto")]
        public async Task<IActionResult> InsertProduto([FromBody] ProdutoInsertParametro produto)
        {
            try
            {
                ProdutoMapper mapper = new ProdutoMapper();
                ProdutoDTO produtoDto = mapper.InsertMapper(produto);
                ProdutosHandler handler = new ProdutosHandler();
                int linhas = await handler.InsertProdutoAsync(produtoDto);
                if (linhas > 0)
                {
                    return Ok();
                }
                else
                {
                    return NotFound("Nenhuma produto adicionado.");
                }
               
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost("AlterarProduto")]
        public async Task<IActionResult> UpdateProduto([FromBody] ProdutoUpdateParametro produto)
        {
            try
            {
                ProdutoMapper mapper = new ProdutoMapper();
                ProdutoDTO produtoDto = mapper.UpdateMapper(produto);
                ProdutosHandler handler = new ProdutosHandler();
                int linhas = await handler.UpdateProdutoAsync(produtoDto);
                if (linhas > 0)
                {
                    return Ok();
                }
                else
                {
                    return NotFound("Nenhuma produto alterado.");
                }

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("DeletarProduto")]
        public async Task<IActionResult> DeleteProduto([FromQuery] int id)
        {
            try
            {
                ProdutosHandler handler = new ProdutosHandler();
                int linhas = await handler.SoftDeleteProdutoAsync(id);
                if (linhas > 0)
                {
                    return Ok();
                }
                else
                {
                    return NotFound("Nenhuma produto alterado.");
                }

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
