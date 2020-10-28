using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Ganss.XSS;
using Polly;
using Polly.Extensions.Http;
using Microsoft.AspNetCore.Routing;
using MyPortfolio.Shared;
using Microsoft.Extensions.Configuration;

namespace MyPortfolio.WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.DefaultScopes.Add("https://schemas.clbmrlsportfolio.com/roles");
            });

            builder.Services.AddScoped<Auth0AuthorizationMessageHandler>();

            var baseAddress = builder.Configuration["HttpClientBaseAddress"];
            builder.Services.AddHttpClient<ProjectApiService>(hc => hc.BaseAddress = new Uri(baseAddress))
                //.AddHttpMessageHandler<Auth0AuthorizationMessageHandler>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());

            builder.Services.AddHttpClient<AuthenticatedProjectApiService>(hc => hc.BaseAddress = new Uri(baseAddress))
                .AddHttpMessageHandler<Auth0AuthorizationMessageHandler>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());

            builder.Services.AddScoped<IHtmlSanitizer, HtmlSanitizer>(x =>
            {
                // Configure sanitizer rules as needed here.
                // For now, just use default rules + allow class attributes
                var sanitizer = new Ganss.XSS.HtmlSanitizer();
                sanitizer.AllowedAttributes.Add("class");
                return sanitizer;
            });

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("slug", typeof(SlugParameterTransformer));
            });

            await builder.Build().RunAsync();
        }
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            var jitterer = new Random();
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) + TimeSpan.FromMilliseconds(jitterer.Next(0, 100)));
        }
    }
}
