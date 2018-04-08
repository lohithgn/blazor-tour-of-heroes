using BlazorTourOfHeroes.Client.Services;
using BlazorTourOfHeroes.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTourOfHeroes.Client.Pages.Heroes
{
    public class IndexModel : BlazorComponent
    {
        [Inject]
        private HeroesServiceClient _client { get; set; }

        public string Name { get; set; }

        protected List<Hero> Model { get; set; }

        protected override async Task OnInitAsync()
        {
            Model = await _client.GetHeroes();
        }

        protected async Task OnHeroCreate()
        {
            Console.WriteLine($"Name : {Name}");
            if (!string.IsNullOrEmpty(Name))
            {
                await _client.CreateHero(Name);
                Name = "";
                await OnInitAsync();
                StateHasChanged();
            }
        }

        protected async Task OnHeroDelete(int id)
        {
            await _client.DeleteHero(id.ToString());
            await OnInitAsync();
            StateHasChanged();
        }

    }
}
