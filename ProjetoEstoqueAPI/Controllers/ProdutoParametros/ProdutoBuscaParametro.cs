namespace ProjetoEstoqueAPI.Controllers.ProdutoParametros
{
    public class ProdutoBuscaParametro
    {
        public int? Id_Produto { get; set; }
        public int? Codigo_Produto { get; set; }
        public string? Nome_Produto { get; set; }
        public float? Valor_Produto { get; set; }
        public int? Id_Categoria { get; set; }
    }
}
