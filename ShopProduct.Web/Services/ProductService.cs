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
            try
            {
                var products = await _httpClient.GetAsync("api/products");
                if(products.IsSuccessStatusCode)
                {
                    if(products.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductReadDto>();
                    }
                    return await products.Content.ReadFromJsonAsync<IEnumerable<ProductReadDto>>();
                }
                else
                {
                    var message = await products.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
             
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductReadDto> GetProduct(int id)
        {
            try
            {
                var product = await _httpClient.GetAsync($"api/products/{id}");
                if (product.IsSuccessStatusCode)
                {
                    if(product.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(ProductReadDto);
                    }
                    return await product.Content.ReadFromJsonAsync<ProductReadDto>();
                }
                else
                {
                    var message = await product.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task AddProduct(ProductAddDto product)
        {
            var result = await _httpClient.PostAsJsonAsync("api/products", product);
            if (!result.IsSuccessStatusCode)
            {
                var message = result.ReasonPhrase;
                Console.WriteLine($"There was an error! {message}");
            }
        }

        public async Task DeleteProduct(int id)
        {
            try
            {
                var delete = await _httpClient.DeleteAsync($"api/products/{id}");
                if (delete.IsSuccessStatusCode)
                {
                    await delete.Content.ReadFromJsonAsync<ProductReadDto>();
                }
                else
                {
                    var message = await delete.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task UpdateProduct(ProductUpdateDto product)
        {
            throw new NotImplementedException();
        }
    }
}
