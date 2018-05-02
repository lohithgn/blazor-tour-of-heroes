using BlazorTourOfHeroes.Client.Services;
using BlazorTourOfHeroes.Shared;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTourOfHeroes.Client.Pages.Heroes
{
    public class DetailModel : BlazorComponent
    {
        [Inject]
        private HeroesServiceClient _client { get; set; }

        public Hero Model { get; set; }

        [Parameter]
        string HeroID { get; set; }

        protected override async Task OnInitAsync()
        {
            Model = await _client.GetHero(HeroID);
        }

        protected void GoBack()
        {
            RegisteredFunction.Invoke<bool>("goBack");
        }

        protected async void UpdateHero()
        {
            await _client.UpdateHero(HeroID, Model.Name);
            GoBack();
        }
    }
}
