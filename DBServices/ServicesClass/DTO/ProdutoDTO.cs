using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.ServicesClass.DTO
{
    public class ProdutoDTO
    {
        public int Id_Produto { get; set; } = int.MinValue;
        public int Codigo_Produto { get; set; } = int.MinValue;
        public string Nome_Produto { get; set; } = string.Empty;
        public float Valor_Produto { get; set; } = float.MinValue;
        public int Id_Categoria { get; set; } = int.MinValue;
        public string Nome_Categoria { get; set; } = string.Empty;

    }
}
