using DBServices.ServicesClass.DTO;

namespace ProjetoEstoque.Class
{
    public class APIConnection
    {
        private readonly HttpClient _http;

        public APIConnection(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> GetProduto()
        {
            return await _http.GetStringAsync("api/Produto/BuscarUmProduto?id=");
        }
        public async Task<string> PostProdutos()
        {
            return await _http.GetStringAsync("api/produto");
        }
    }
}
