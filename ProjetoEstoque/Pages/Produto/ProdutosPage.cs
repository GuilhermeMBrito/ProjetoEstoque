using DBServices.ServicesClass.DTO;
using DBServices.ServicesClass.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ProjetoEstoque.Class;
using System.Drawing;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ProjetoEstoque.Pages.Produto
{
    public partial class ProdutosPage
    {
        #region "Injeção"
        protected HttpClient _httpClient;
        private ConfirmModal confirmModal;
        [Inject]
        protected HttpClient HttpClient
        {
            get => _httpClient;
            set => _httpClient = value;
        }
        #endregion

        #region "Busca"
        private int IdProdutoBusca { get; set; }
        private int CodigoProdutoBusca { get; set; }
        private string NomeProdutoBusca { get; set; }
        private int? categoriaSelecionadaBusca;
        private IList<ProdutoDTO>? produtos;
        #endregion
        #region "Modal"
        private int size = 200;
        private bool isOpenConfirmModal = false;
        private string ModalTitle = "";
        #region "Delete"
        private string DeleteImage = $"/images/remove.png";
        private int DeleteIdProduto { get; set; }
        private bool DeleteModal = false;
        #endregion
        #region "Adicionar/Alterar"
        private string EditImage = $"/images/edit.png";
        private bool AddicionarModal = false;
        private bool AlterarModal = false;
        private int IdProdutoModal;
        private int CodigoProdutoModal;
        private string NomeProdutoModal;
        private int categoriaSelecionadaModal;
        private float ValorModal;
        #endregion
        #endregion
        private List<CategoriaDTO> categorias;
        protected override async Task OnInitializedAsync()
        {
            var response = await _httpClient.GetAsync("api/Categoria/BuscarCategoria");

            var json = await response.Content.ReadAsStringAsync();

            categorias = JsonSerializer.Deserialize<List<CategoriaDTO>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            categoriaSelecionadaBusca = -1;
        }

        private async Task Buscar()
        {
            try
            {
                ProdutoDTO produtoDTO = new ProdutoDTO();
                if (IdProdutoBusca > 0)
                {
                    produtoDTO.Id_Produto = IdProdutoBusca;
                }
                if (CodigoProdutoBusca > 0)
                {
                    produtoDTO.Codigo_Produto = CodigoProdutoBusca;
                }

                if (!string.IsNullOrEmpty(NomeProdutoBusca))
                {
                    produtoDTO.Nome_Produto = NomeProdutoBusca;
                }
                if (categoriaSelecionadaBusca > 0)
                {
                    produtoDTO.Id_Categoria = (int)categoriaSelecionadaBusca;
                }
                var response = await _httpClient.PostAsJsonAsync("api/Produto/BuscarProdutos", produtoDTO);

                var json = await response.Content.ReadAsStringAsync();

                produtos = JsonSerializer.Deserialize<List<ProdutoDTO>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                LimparCampos();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected async Task AbrirModalAlterar(int idProduto)
        {
            try
            {
               
                ProdutoDTO produtoDTO = new ProdutoDTO();
                produtoDTO.Id_Produto = idProduto;
                IdProdutoModal = idProduto;
                var response = await _httpClient.GetAsync("api/Produto/BuscarUmProduto?id=" + idProduto.ToString());
                var json = await response.Content.ReadAsStringAsync();
                ProdutoDTO list = JsonSerializer.Deserialize<ProdutoDTO>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                if (list != null)
                {
                    CodigoProdutoModal = list.Codigo_Produto;
                    ValorModal = list.Valor_Produto;
                    NomeProdutoModal = list.Nome_Produto;
                    categoriaSelecionadaModal = list.Id_Categoria;
                    ModalTitle = "Alterar Produto";
                    size = 700;
                    isOpenConfirmModal = true;
                    DeleteModal = false;
                    AddicionarModal = false;
                    AlterarModal = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected async Task AlterarProduto()
        {
            ProdutoDTO produtoDTO = new ProdutoDTO();
            produtoDTO.Id_Produto = IdProdutoModal;
            produtoDTO.Codigo_Produto = CodigoProdutoModal;
            produtoDTO.Nome_Produto = NomeProdutoModal;
            produtoDTO.Valor_Produto = ValorModal;
            produtoDTO.Id_Categoria = categoriaSelecionadaModal;
            var response = await _httpClient.PostAsJsonAsync("api/Produto/AlterarProduto", produtoDTO);
            FecharModal();
            LimparCampos();
            IdProdutoBusca = produtoDTO.Id_Produto;
            await Buscar();

        }
        protected async Task AbrirModalAdicionar()
        {
            size = 700;
            ModalTitle = "Alterar Produto";
            isOpenConfirmModal = true;
            DeleteModal = false;
            AddicionarModal = true;
            AlterarModal = false;
            CodigoProdutoModal = 0;
            NomeProdutoModal = "";
            categoriaSelecionadaModal = -1;
            ValorModal = 0;
        }
        protected async Task AdicionarProduto()
        {
            ProdutoDTO produtoDTO = new ProdutoDTO();
            produtoDTO.Codigo_Produto = CodigoProdutoModal;
            produtoDTO.Nome_Produto = NomeProdutoModal;
            produtoDTO.Valor_Produto = ValorModal;
            produtoDTO.Id_Categoria = categoriaSelecionadaModal;
            var response = await _httpClient.PostAsJsonAsync("api/Produto/InserirProduto", produtoDTO);

            FecharModal();
            LimparCampos();
            CodigoProdutoBusca = CodigoProdutoModal;
            await Buscar();
        }

        protected void DeletarModal(int produto)
        {
            ModalTitle = "Excluir Produto";
            size = 200;
            isOpenConfirmModal = true;
            DeleteModal = true;
            AddicionarModal = false;
            AlterarModal = false;
            DeleteIdProduto = produto;
        }
        protected async Task DeletarProduto()
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Produto/DeletarProduto?id={DeleteIdProduto}");
                var json = await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharModal();
                await Buscar();
            }
        }

        private void FecharModal()
        {
            isOpenConfirmModal = false;
            DeleteModal = false;
            AddicionarModal = false;
            AlterarModal = false;
        }

        private void LimparCampos()
        {
            IdProdutoBusca = 0;
            CodigoProdutoBusca = 0;
            NomeProdutoBusca = "";
            categoriaSelecionadaBusca = -1;
        }
    }
}
