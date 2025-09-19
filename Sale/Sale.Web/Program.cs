using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sale.Web;
using Sale.Web.Repositorio;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazorBootstrap();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7255/") });
builder.Services.AddScoped<ConsumoPais>();


await builder.Build().RunAsync();
