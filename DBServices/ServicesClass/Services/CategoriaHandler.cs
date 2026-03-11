using DBServices.ServicesClass.DTO;
using DBServices.ServicesClass.Mapper;
using DBServices.ServicesClass.SQLCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.ServicesClass.Services
{
    public class CategoriaHandler : DBService
    {
        public async Task<CategoriaDTO> BuscarUmaCategoriaAsync(int id_categoria)
        {
            CategoriaComandosSQL commando = new CategoriaComandosSQL();
            return MapperCategoria.MapperUmaCategoria(await dbConnection.ConsultaUmSQLAsync(commando.BuscarUmCategoriaComando(id_categoria)));
        }
        public async Task<IList<CategoriaDTO>> BuscarCategoriasAsync(CategoriaDTO categoria)
        {
            CategoriaComandosSQL commando = new CategoriaComandosSQL();
            return MapperCategoria.MapperCategorias(await dbConnection.ConsultaVariosSQLAsync(commando.BuscarCategoriasComando(categoria)));
        }
    }
}
