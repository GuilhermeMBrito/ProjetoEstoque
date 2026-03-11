using DBServices.ServicesClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.ServicesClass.Mapper
{
    public class MapperProduto
    {
        public static ProdutoDTO MapperUmProduto(IList<string> list)
        {
            ProdutoDTO dto = new ProdutoDTO();
            if (!string.IsNullOrEmpty(list[0]))
            {
                dto.Id_Produto = int.Parse(list[0]);
            }
            if (!string.IsNullOrEmpty(list[1]))
            {
                dto.Codigo_Produto = int.Parse(list[1]);
            }
            if (!string.IsNullOrEmpty(list[2]))
            {
                dto.Nome_Produto = list[2];
            }
            if (!string.IsNullOrEmpty(list[3]))
            {
                dto.Valor_Produto = float.Parse(list[3]);
            }
            if (!string.IsNullOrEmpty(list[4]))
            {
                dto.Id_Categoria = int.Parse(list[4].ToString());
            }
            if (!string.IsNullOrEmpty(list[5]))
            {
                dto.Nome_Categoria = list[5];
            }
            return dto;
        }
        public static IList<ProdutoDTO> MapperProdutos(IList<IList<string>> list)
        {
            IList<ProdutoDTO> produtos = new List<ProdutoDTO>();

            foreach (IList<string> item in list)
            {
                produtos.Add(MapperUmProduto(item));
            }
            return produtos;
        }
    }
}