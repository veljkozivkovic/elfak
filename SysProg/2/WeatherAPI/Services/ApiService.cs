using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherAPI.Services
{
    public class ApiService
    {
        private readonly string baseUrl;
        private readonly string apiKey;
        private readonly HttpClient client;
        private readonly string day;

        public ApiService(string baseUrl, string apiKey, string day)
        {
            this.baseUrl = baseUrl;
            this.apiKey = apiKey;
            this.client = new HttpClient();
            this.day = day;
        }

        public async Task<JObject> FetchDataAsync(string query)
        {
            try
            {
                string url = $"{baseUrl}?key={apiKey}&q={query}&days={day}&aqi=yes&alerts=no&lang=sr";
                //Console.WriteLine($"Request URL: {url}");

                var response = await client.GetAsync(url).ConfigureAwait(false);
               
                //Console.WriteLine($"Response status code: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    var resBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    

                    return JObject.Parse(resBody);
                }
                else
                {
                    //Console.WriteLine($"Error: {response.ReasonPhrase}");
                    return null;
                }
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                return null;
            }
        }
    }
}