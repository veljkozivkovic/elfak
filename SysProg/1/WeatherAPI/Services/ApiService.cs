using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public JObject FetchData(string query)
        {
            try
            {
                string url = $"{baseUrl}?key={apiKey}&q={query}&days={day}&aqi=yes&alerts=no&lang=sr";
                var response = client.GetAsync(url).Result;
                var resBody = response.Content.ReadAsStringAsync().Result;
                return JObject.Parse(resBody);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            
               


            
            
       
        }

    }
}
