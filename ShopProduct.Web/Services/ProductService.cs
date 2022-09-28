using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.FileProviders;
using ShopProduct.Api.Dtos;
using ShopProduct.Web.Pages;
using ShopProduct.Web.Services.Contracts;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using static System.Net.WebRequestMethods;

namespace ShopProduct.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductReadDto>> GetProducts()
        {
            var products = await _httpClient.GetAsync("api/products");
            return await products.Content.ReadFromJsonAsync<IEnumerable<ProductReadDto>>();
        }

        public async Task<ProductReadDto> GetProduct(int id)
        {
            var product = await _httpClient.GetAsync($"api/products/{id}");
            return await product.Content.ReadFromJsonAsync<ProductReadDto>();
        }

        public async Task AddProduct(ProductAddDto product)
        {
            var result = await _httpClient.PostAsJsonAsync("api/products", product);
        }

        public async Task DeleteProduct(int id)
        {        
           var delete = await _httpClient.DeleteAsync($"api/products/{id}");              
        }

        public async Task UpdateProduct(int id, ProductUpdateDto product)
        {
            var delete = await _httpClient.PutAsJsonAsync($"api/products/{id}", product);
        }
    }
}
