using ShopProduct.Api.Dtos;

namespace ShopProduct.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDto>> GetProducts();
        Task<ProductReadDto> GetProduct(int id);
        Task AddProduct(ProductAddDto product);  
        Task UpdateProduct(ProductUpdateDto product);
        Task DeleteProduct(int id);
    }
}
