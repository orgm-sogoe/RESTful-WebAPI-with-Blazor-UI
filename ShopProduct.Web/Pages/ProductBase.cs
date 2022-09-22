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
        public IProductService ProductService { get; set; }
        public ProductReadDto Product { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetProduct(Id);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }         
        }

        public async Task Delete()
        {
            try
            {
                await ProductService.DeleteProduct(Id);               
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
    }
}
