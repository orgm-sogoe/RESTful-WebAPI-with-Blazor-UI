using Microsoft.AspNetCore.Components;
using ShopProduct.Api.Dtos;
using ShopProduct.Web.Services.Contracts;

namespace ShopProduct.Web.Pages
{
    public class ProductBase : ComponentBase
    {
       
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }
        public ProductReadDto Product { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
           Product = await ProductService.GetProduct(Id);   
        }

        public async Task Delete()
        {
            await ProductService.DeleteProduct(Id);
        }

        public void ToUpdate(int Id)
        {
            NavigationManager.NavigateTo($"updateproduct/{Id}", true);
        }
    }
}
