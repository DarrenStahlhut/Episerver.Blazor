using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContentDeliveryAPI.Library
{
    public class SearchService
    {

        public async Task<ViewModels.SearchResults> Search(string query, int top, int skip, string acceptLanguage = "en")
        {
            var searchResults = new ViewModels.SearchResults();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", acceptLanguage);

            HttpResponseMessage response = await client.GetAsync($"http://localhost:53272/api/episerver/v2.0/search/content?query={query}&skip={skip}&top={top}&expand=*&filter=ContentType/any(t:t eq 'Page')").ConfigureAwait(false);
            //HttpResponseMessage response = await client.GetAsync("http://localhost:53272/api/episerver/v2.0/search/content?query=bears&skip=0&top=10&expand=*&filter=ContentType/any(t:t eq 'Page')").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            var rawResults = Models.SearchResults.FromJson(responseBody);

            if (rawResults != null)
            {
                searchResults.TotalMatching = rawResults.TotalMatching;
                searchResults.Results = rawResults.Results.Select(r => new ViewModels.Result
                {
                    Title = r.Name,
                    Excerpt = r.MetaDescription.Value.String,
                    Url = r.Url
                }).ToList();
            }

            return searchResults;
        }

    }
}
