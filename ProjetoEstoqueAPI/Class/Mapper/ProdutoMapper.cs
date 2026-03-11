using DBServices.ServicesClass.DTO;
using ProjetoEstoqueAPI.Controllers.ProdutoParametros;

namespace ProjetoEstoqueAPI.Class.Mapper
{
    public class ProdutoMapper
    {
        public ProdutoDTO BuscaMapper(ProdutoBuscaParametro produto)
        {
            ProdutoDTO produtoDto = new ProdutoDTO();
            if (produto.Id_Produto > 0)
            {
                produtoDto.Id_Produto = (int)produto.Id_Produto;
            }
            if (produto.Codigo_Produto > 0)
            {
                produtoDto.Codigo_Produto = (int)produto.Codigo_Produto;
            }
            if (!string.IsNullOrEmpty(produto.Nome_Produto))
            {
                produtoDto.Nome_Produto = produto.Nome_Produto;
            }
            if (produto.Valor_Produto > 0)
            {
                produtoDto.Valor_Produto = (int)produto.Valor_Produto;
            }
            if (produto.Id_Categoria > 0)
            {
                produtoDto.Id_Categoria = (int)produto.Id_Categoria;
            }
            return produtoDto;
        }
        public ProdutoDTO UpdateMapper(ProdutoUpdateParametro produto)
        {
            bool possuiParametro = false;
            ProdutoDTO produtoDto = new ProdutoDTO();
            if (produto.Id_Produto > 0 )
            {
                produtoDto.Id_Produto = (int)produto.Id_Produto;
            }
            else
            {
                throw new ArgumentException("Produto inválido, necessario o ID do produto para modificar.");
            }
            if (produto.Codigo_Produto > 0)
            {
                produtoDto.Codigo_Produto = (int)produto.Codigo_Produto;
                possuiParametro = true;
            }
            if (!string.IsNullOrEmpty(produto.Nome_Produto))
            {
                produtoDto.Nome_Produto = produto.Nome_Produto;
                possuiParametro = true;
            }
            if (produto.Valor_Produto > 0)
            {
                produtoDto.Valor_Produto = (float)produto.Valor_Produto;
                possuiParametro = true;
            }
            if (produto.Id_Categoria > 0)
            {
                produtoDto.Id_Categoria = (int)produto.Id_Categoria;
                possuiParametro = true;
            }
            if (!possuiParametro)
            {
                throw new ArgumentException("Produto inválido, necessario ao menos um parâmetro para modificar.");
            }
            return produtoDto;
        }
        public ProdutoDTO InsertMapper(ProdutoInsertParametro produto)
        {
            ProdutoDTO produtoDto = new ProdutoDTO();           
            if (produto.Codigo_Produto > 0)
            {
                produtoDto.Codigo_Produto = (int)produto.Codigo_Produto;
            }
            else
            {
                throw new ArgumentException("Produto inválido, necessario o Codigo do Produto.");
            }
            if (!string.IsNullOrEmpty(produto.Nome_Produto))
            {
                produtoDto.Nome_Produto = produto.Nome_Produto;
            }
            else
            {
                throw new ArgumentException("Produto inválido, necessario o Nome do Produto.");
            }
            if (produto.Valor_Produto > 0)
            {
                produtoDto.Valor_Produto = (float)produto.Valor_Produto;
            }
            else
            {
                throw new ArgumentException("Produto inválido, necessario o Valor do Produto.");
            }
            if (produto.Id_Categoria > 0)
            {
                produtoDto.Id_Categoria = (int)produto.Id_Categoria;
            }
            else
            {
                throw new ArgumentException("Produto inválido, necessario o Categoria do Produto.");
            }

            return produtoDto;
        }
    }
}
