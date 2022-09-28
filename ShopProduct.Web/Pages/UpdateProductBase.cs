using Microsoft.AspNetCore.Components;
using ShopProduct.Api.Dtos;
using ShopProduct.Web.Services;
using ShopProduct.Web.Services.Contracts;
using System.Runtime.Serialization;

namespace ShopProduct.Web.Pages
{
    public class UpdateProductBase: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }   

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }
        public ProductReadDto ToUpdate { get; set; } 
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {

            ToUpdate = await ProductService.GetProduct(Id);
        }

        public async void HandleValidSubmit(ProductReadDto product)
        {
            var updatedProduct = new ProductUpdateDto 
            { 
              Id= product.Id, 
              Name= product.Name,
              Description= product.Description,
              Price= product.Price,
              Quantity= product.Quantity,   
            };
        await ProductService.UpdateProduct(Id, updatedProduct);
        NavigationManager.NavigateTo("/", true);
        }
    }
}

