using DBServices.ServicesClass.DTO;
using DBServices.ServicesClass.Mapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.ServicesClass.SQLCommand
{
    public class ProdutoComandosSQL
    {
        public string BuscarUmProdutoComando(int id_produto)
        {
            StringBuilder strinbBuilder = new StringBuilder("Select Top 1 T1.id_produto, T1.codigo_produto, T1.nome_produto, T1.valor_produto, T1.id_categoria, T2.nome_categoria from Produto T1 ");
            strinbBuilder.Append(" inner join Categoria T2 on T1.id_categoria = T2.id_categoria ");
            strinbBuilder.Append($" where id_produto = {id_produto}");
            return strinbBuilder.ToString();
        }
        public string BuscarProdutosComando(ProdutoDTO produto)
        {
            StringBuilder strinbBuilder = new StringBuilder("Select T1.id_produto, T1.codigo_produto, T1.nome_produto, T1.valor_produto, T1.id_categoria, T2.nome_categoria from Produto T1 ");
            strinbBuilder.Append(" inner join Categoria T2 on T1.id_categoria = T2.id_categoria ");
            strinbBuilder.Append($" where ISNULL(convert(int,T1.deletado),0) = 0 ");
            if (produto.Id_Produto > 0)
            {
                strinbBuilder.Append($" and  T1.id_produto = {produto.Id_Produto} ");
            }
            if (produto.Codigo_Produto > 0)
            {
                strinbBuilder.Append($" and T1.codigo_produto = {produto.Codigo_Produto} ");
            }
            if (!String.IsNullOrEmpty(produto.Nome_Produto))
            {
                strinbBuilder.Append($" and T1.nome_produto like '%{produto.Nome_Produto}%' ");
            }
            if (produto.Valor_Produto > float.MinValue)
            {
                strinbBuilder.Append($" and  T1.valor_produto = {produto.Valor_Produto.ToString(CultureInfo.InvariantCulture)} ");
            }
            if (produto.Id_Categoria > 0)
            {
                strinbBuilder.Append($" and  T2.id_categoria = {produto.Id_Categoria} ");
            }
            if (!String.IsNullOrEmpty(produto.Nome_Categoria))
            {
                strinbBuilder.Append($" and T2.nome_categoria like '%{produto.Nome_Categoria}%' ");
            }
            return strinbBuilder.ToString();
        }

        public string InsertProdutoComando(ProdutoDTO produto)
        {
            StringBuilder strinbBuilder = new StringBuilder("insert into produto (codigo_produto, nome_produto, valor_produto, id_categoria) Values");
            strinbBuilder.Append($"(");
            strinbBuilder.Append($" {(produto.Codigo_Produto > 0 ? produto.Codigo_Produto : "null")}, ");
            strinbBuilder.Append($" '{(!string.IsNullOrEmpty(produto.Nome_Produto) ? produto.Nome_Produto : "")}', ");
            strinbBuilder.Append($" {(produto.Valor_Produto > 0 ? produto.Valor_Produto.ToString(CultureInfo.InvariantCulture) : "null")}, ");
            strinbBuilder.Append($" {(produto.Id_Categoria > 0 ? produto.Id_Categoria : "null")} ");
            strinbBuilder.Append($")");
            return strinbBuilder.ToString();
        }

        public string UpdateProdutoComando(ProdutoDTO produto)
        {
            bool temVirgula = false;
            StringBuilder strinbBuilder = new StringBuilder(" update produto set ");
            if (produto.Codigo_Produto > 0)
            {
                if (temVirgula)
                {
                    strinbBuilder.Append(" , ");
                }
                else
                {
                    temVirgula = true;
                }
                strinbBuilder.Append($" codigo_produto = {produto.Codigo_Produto} ");
            }

            if (!string.IsNullOrEmpty(produto.Nome_Produto))
            {
                if (temVirgula)
                {
                    strinbBuilder.Append(" , ");
                }
                else
                {
                    temVirgula = true;
                }
                strinbBuilder.Append($" nome_produto = '{produto.Nome_Produto}' ");
            }

            if (produto.Valor_Produto > 0)
            {
                if (temVirgula)
                {
                    strinbBuilder.Append(" , ");
                }
                else
                {
                    temVirgula = true;
                }
                strinbBuilder.Append($" valor_produto = {produto.Valor_Produto.ToString(CultureInfo.InvariantCulture)} ");
            }
            if (produto.Id_Categoria > 0)
            {
                if (temVirgula)
                {
                    strinbBuilder.Append(" , ");
                }
                else
                {
                    temVirgula = true;
                }
                strinbBuilder.Append($" id_categoria = {produto.Id_Categoria} ");
            }
            strinbBuilder.Append($" where id_produto = {produto.Id_Produto}");
            return strinbBuilder.ToString();
        }
        public string SoftDeleteProdutoComando(int id_produto)
        {
            StringBuilder strinbBuilder = new StringBuilder(" update produto set deletado = 1 ");
            strinbBuilder.Append($" where id_produto = {id_produto}");
            return strinbBuilder.ToString();
        }
    }
}
