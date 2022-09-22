using Microsoft.AspNetCore.Components;
using ShopProduct.Api.Dtos;
using ShopProduct.Web.Services.Contracts;

namespace ShopProduct.Web.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        public IEnumerable<ProductReadDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetProducts();
        }
    }
}
