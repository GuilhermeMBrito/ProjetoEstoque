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
    public class ProdutosHandler : DBService
    {
        public async Task<IList<ProdutoDTO>> BuscarProdutosAsync(ProdutoDTO produto)
        {
            ProdutoComandosSQL commando = new ProdutoComandosSQL();
            return MapperProduto.MapperProdutos(await dbConnection.ConsultaVariosSQLAsync(commando.BuscarProdutosComando(produto)));
        }
        public async Task<ProdutoDTO> BuscarUmProdutoAsync(int id_produto)
        {
            ProdutoComandosSQL commando = new ProdutoComandosSQL();
            return MapperProduto.MapperUmProduto(await dbConnection.ConsultaUmSQLAsync(commando.BuscarUmProdutoComando(id_produto)));
        }
        public async Task<int> InsertProdutoAsync(ProdutoDTO produto)
        {
            ProdutoComandosSQL commando = new ProdutoComandosSQL();
            return await dbConnection.EnviarDadosSQLAsync(commando.InsertProdutoComando(produto));
        }
        public async Task<int> UpdateProdutoAsync(ProdutoDTO produto)
        {
            ProdutoComandosSQL commando = new ProdutoComandosSQL();

            return await dbConnection.EnviarDadosSQLAsync(commando.UpdateProdutoComando(produto));
        }
        public async Task<int> SoftDeleteProdutoAsync(int id_produto)
        {
            ProdutoComandosSQL commando = new ProdutoComandosSQL();
            return await dbConnection.EnviarDadosSQLAsync(commando.SoftDeleteProdutoComando(id_produto));
        }
    }
}
