using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Ganss.XSS;

namespace MyPortfolio.WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var baseAddress = builder.Configuration["HttpClientBaseAddress"];
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            builder.Services.AddScoped<ProjectApiService>();
            builder.Services.AddScoped<IHtmlSanitizer, HtmlSanitizer>(x =>
            {
                // Configure sanitizer rules as needed here.
                // For now, just use default rules + allow class attributes
                var sanitizer = new Ganss.XSS.HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");
                return sanitizer;
            });

            await builder.Build().RunAsync();
        }
    }
}
