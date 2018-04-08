using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using BlazorTourOfHeroes.Client.Services;

namespace BlazorTourOfHeroes.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(configure =>
            {
                // Add any custom services here
                configure.AddSingleton<HeroesServiceClient>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
