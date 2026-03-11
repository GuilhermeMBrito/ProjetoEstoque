using Microsoft.AspNetCore.Components;

namespace ProjetoEstoque.Pages
{
    public partial class ConfirmModal
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment FooterContent { get; set; }
        [Parameter]
        public bool IsOpen { get; set; }

        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }
        [Parameter]
        public int Width { get; set; }
        [Parameter]
        public int Height { get; set; }
        private string Message = "";
        private string Size => Width > 0 && Height > 0 ? $"width: {Width}px;height: {Height}px; " : "";
        private string ModalStyle => IsOpen ? "display: block;" : "display: none;";
        public async Task CloseModal()
        {
            IsOpen = false;
            await IsOpenChanged.InvokeAsync(false);
        }
    }
}
