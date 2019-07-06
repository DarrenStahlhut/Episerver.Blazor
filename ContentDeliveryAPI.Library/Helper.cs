using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContentDeliveryAPI.Library
{
    public static class Helper
    {

        public static async Task<string> Search(string query, int top, int skip, string acceptLanguage = "en")
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", acceptLanguage);

            //HttpResponseMessage response = await client.GetAsync("http://localhost:53272/api/episerver/v2.0/search/content?query={query}&skip={skip}&top={top}&expand=*&filter=ContentType/any(t:t eq 'Page')").ConfigureAwait(false);
            HttpResponseMessage response = await client.GetAsync("http://localhost:53272/api/episerver/v2.0/search/content?query=bears&skip=0&top=10&expand=*&filter=ContentType/any(t:t eq 'Page')").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

    }
}
