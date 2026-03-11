namespace ProjetoEstoqueAPI.Controllers.ProdutoParametros
{
    public class ProdutoInsertParametro
    {
        public int Codigo_Produto { get; set; }
        public string Nome_Produto { get; set; }
        public float Valor_Produto { get; set; }
        public int Id_Categoria { get; set; }
    }
}
