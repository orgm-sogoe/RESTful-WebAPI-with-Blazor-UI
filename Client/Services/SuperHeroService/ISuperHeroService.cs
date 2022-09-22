using ShopProduct.Api.Dtos;

namespace ShopProduct.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<ProductReadDto> Products { get; set; }
        Task GetProducts();
        Task<ProductReadDto> GetSingleProduct(int id);
        Task CreateProduct(ProductAddDto add);
        Task UpdateProduct(ProductUpdateDto update);
        Task DeleteProduct(int id);
    }
}
