using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShopProduct.Web;
using ShopProduct.Web.Pages;
using ShopProduct.Web.Services;
using ShopProduct.Web.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7136") });
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
