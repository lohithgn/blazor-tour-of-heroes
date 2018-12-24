using BlazorTourOfHeroes.Client.Services;
using BlazorTourOfHeroes.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
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
            JSRuntime.Current.InvokeAsync<bool>("tourOfHeroesFunctions.goBack");
        }

        protected async void UpdateHero()
        {
            await _client.UpdateHero(HeroID, Model.Name);
            GoBack();
        }
    }
}
