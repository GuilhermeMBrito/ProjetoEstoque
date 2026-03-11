using DBServices.ServicesClass.DTO;
using DBServices.ServicesClass.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.ServicesClass.SQLCommand
{
    public class CategoriaComandosSQL
    {
        public string BuscarUmCategoriaComando(int id_categoria)
        {
            StringBuilder strinbBuilder = new StringBuilder("Select Top 1 T1.id_categoria, T1.nome_categoria from Categoria T1 ");
            strinbBuilder.Append($" where id_categoria = {id_categoria} ");            
            return strinbBuilder.ToString();
        }
        public string BuscarCategoriasComando(CategoriaDTO categoria)
        {
            StringBuilder strinbBuilder = new StringBuilder("Select T1.id_categoria, T1.nome_categoria from Categoria T1 ");
            strinbBuilder.Append($" where ISNULL(convert(int,T1.deletado),0) = 0 ");
            if (categoria.Id_Categoria > 0)
            {
                strinbBuilder.Append($" and  T1.id_categoria = {categoria.Id_Categoria} ");
            }
            if (!String.IsNullOrEmpty(categoria.Nome_Categoria))
            {
                strinbBuilder.Append($" and T1.nome_categoria like '%{categoria.Nome_Categoria}%' ");
            }
           return strinbBuilder.ToString();
        }
    }
}
