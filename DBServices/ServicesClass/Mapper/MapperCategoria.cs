using DBServices.ServicesClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.ServicesClass.Mapper
{
    public class MapperCategoria
    {
        public static CategoriaDTO MapperUmaCategoria(IList<string> list)
        {
            CategoriaDTO dto = new CategoriaDTO();
            if (!string.IsNullOrEmpty(list[0]))
            {
                dto.Id_Categoria = int.Parse(list[0]);
            }
            if (!string.IsNullOrEmpty(list[1]))
            {
                dto.Nome_Categoria = list[1];
            }
            return dto;
        }
        public static IList<CategoriaDTO> MapperCategorias(IList<IList<string>> list)
        {
            IList<CategoriaDTO> categorias = new List<CategoriaDTO>();

            foreach (IList<string> item in list)
            {
                categorias.Add(MapperUmaCategoria(item));
            }
            return categorias;
        }
    }
}
