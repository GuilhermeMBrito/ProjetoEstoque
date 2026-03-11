using DBServices.ServicesClass.DTO;
using DBServices.ServicesClass.Services;
using Microsoft.AspNetCore.Mvc;
using ProjetoEstoqueAPI.Class.Mapper;
using ProjetoEstoqueAPI.Controllers.ProdutoParametros;

namespace ProjetoEstoqueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;

        public CategoriaController(ILogger<ProdutoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("BuscarCategoria")]
        public async Task<IActionResult> BuscarCategoria()
        {
            try
            {
                CategoriaDTO categoriaDTO = new CategoriaDTO() ;

                CategoriaHandler handler = new CategoriaHandler();
                IList<CategoriaDTO> categorias = await handler.BuscarCategoriasAsync(categoriaDTO);
                if (categorias.Count > 0)
                {
                    return Ok(categorias);
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
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
    }
}
