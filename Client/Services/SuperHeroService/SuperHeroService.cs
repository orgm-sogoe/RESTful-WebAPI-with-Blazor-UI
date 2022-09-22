using Microsoft.AspNetCore.Components;
using ShopProduct.Api.Dtos;
using System.Net.Http.Json;

namespace ShopProduct.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public SuperHeroService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<ProductReadDto> Products { get; set; } = new List<ProductReadDto>();

        //public List<Comic> Comics { get; set; } = new List<Comic>();

        public async Task CreateProduct(ProductAddDto add)
        {
            var result = await _http.PostAsJsonAsync("api/products", add);
            await SetProducts(result);
        }

        private async Task SetProducts(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<ProductReadDto>>();
            Products = response;
            _navigationManager.NavigateTo("superheroes");
        }

        public async Task DeleteProduct(int id)
        {
            var result = await _http.DeleteAsync($"api/products/{id}");
            await SetProducts(result);
        }

        public async Task<ProductReadDto> GetSingleProduct(int id)
        {
            var result = await _http.GetFromJsonAsync<ProductReadDto>($"api/products/{id}");
            if (result != null)
                return result;
            throw new Exception("Product not found!");
        }

        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<List<ProductReadDto>>("api/products");
            if (result != null)
                Products = result;
        }

        public async Task UpdateProduct(ProductUpdateDto update)
        {
            var result = await _http.PutAsJsonAsync($"api/superhero/{update.Id}", update);
            await SetProducts(result);
        }
    }
}
