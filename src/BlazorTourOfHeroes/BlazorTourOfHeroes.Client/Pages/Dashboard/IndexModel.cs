using BlazorTourOfHeroes.Client.Services;
using BlazorTourOfHeroes.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTourOfHeroes.Client.Pages.Dashboard
{
    public class IndexModel : BlazorComponent
    {
        public IndexModel()
        {
            
        }
        [Inject]
        private HeroesServiceClient _client { get; set; }
        public List<Hero> Heroes { get; set; }
        public List<Hero> SearchResults { get; set; }

        public string SearchCriteria { get; set; }
        public bool SearchInProgress { get; set; } = false;
        
        protected async void SearchHeroes()
        {
            SearchInProgress = true;
            SearchResults = await _client.SearchHeroes(SearchCriteria);
            SearchInProgress = false;
            this.StateHasChanged();
        }

        protected override async Task OnInitAsync()
        {
            Heroes = await _client.GetTopHeroes();
        }

    }
}
