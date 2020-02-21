using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace TerminalApp_Recipes
{
    public class HttpRequest
    {
        public static string GenerateUrl(string keywords, int? to, int? ingr, string? diet)
        {
            string baseUrl = $"https://api.edamam.com/search?q={keywords}&app_id={keys.app_id}&app_key={keys.app_key}";
            if (to == null && ingr == null && diet ==null)
            {
                return baseUrl ;
            } else if (ingr == null && diet == null)
            {
                return (baseUrl + $"&from=0&to={to}");
            }
            else if (diet == null)
            {
                return (baseUrl + $"&from=0&to={to}&ingr={ingr}");
            } else if (to == null && ingr == null)
            {
                return (baseUrl + $"&diet={diet}");
            } else if (to == null && diet == null)
            {
                return (baseUrl + $"&ingr={ingr}");
            } else if (ingr == null)
            {
                return (baseUrl + $"&from=0&to={to}&diet={diet}");
            } else //to null
            {
                return (baseUrl + $"&diet={diet}&ingr={ingr}");
            }

        }

        public static string MakeApiRequest(string url)
        {

            HttpClient client = new HttpClient();
            var clientResponse = client.GetAsync(url).Result;
            return clientResponse.Content.ReadAsStringAsync().Result;
        }
    }
}
