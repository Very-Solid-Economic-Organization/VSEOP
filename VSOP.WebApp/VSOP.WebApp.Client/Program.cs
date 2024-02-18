using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

namespace VSOP.WebApp.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddRadzenComponents();

            await builder.Build().RunAsync();
        }
    }
}
