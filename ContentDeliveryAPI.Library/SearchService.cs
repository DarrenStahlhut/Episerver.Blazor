using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContentDeliveryAPI.Library
{
    public class SearchService
    {

        public async Task<ViewModels.SearchResults> Search(string query, int page, int pageSize, string acceptLanguage = "en")
        {
            var searchResults = new ViewModels.SearchResults();
            try
            {
                HttpClient client = new HttpClient();
                using (client)
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", acceptLanguage);

                    //get some paging props
                    var skip = (page-1) * pageSize;
                    var top = pageSize;

                    HttpResponseMessage response = await client.GetAsync($"http://localhost:53272/api/episerver/v2.0/search/content?query={query}&skip={skip}&top={top}&expand=*&filter=ContentType/any(t:t eq 'Page')").ConfigureAwait(false);
                    //HttpResponseMessage response = await client.GetAsync("http://localhost:53272/api/episerver/v2.0/search/content?query=bears&skip=0&top=10&expand=*&filter=ContentType/any(t:t eq 'Page')").ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();

                    var rawResults = Models.SearchResults.FromJson(responseBody);

                    if (rawResults != null)
                    {
                        searchResults.TotalMatching = (int)rawResults.TotalMatching;                        
                        searchResults.SearchTerm = query;
                        if (rawResults.TotalMatching > 0)
                        {
                            //set pager
                            searchResults.Pager = new ViewModels.Pager(searchResults.TotalMatching, page, pageSize);

                            //set results
                            searchResults.Results = rawResults.Results.Select(r => new ViewModels.Result
                            {
                                Title = r.Name,
                                Excerpt = r.MetaDescription.Value,
                                Url = r.Url
                            }).ToList();
                        }
                    }
                    response.Dispose();
                }
            }
            catch (Exception e)
            {
                //do nothing, return empty results
            }

            return searchResults;
        }

    }
}
