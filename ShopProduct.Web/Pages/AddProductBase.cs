using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using ShopProduct.Api.Dtos;
using ShopProduct.Web.Services.Contracts;

namespace ShopProduct.Web.Pages
{
    public class AddProductBase: ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }  
        public ProductAddDto product { get; set; } = new ProductAddDto { };
        public string ErrorMessage { get; set; }

        public async void HandleValidSubmit()
        {
            try
            {
                await ProductService.AddProduct(product);
                NavigationManager.NavigateTo("/", true);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
