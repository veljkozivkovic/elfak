using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Utils;
using WeatherAPI.LFUCache;

namespace WeatherAPI.Services
{
    public static class Handler
    {
        public static void HandleRequest(object contextObj , LFU cache)
        {
            HttpListenerContext context = (HttpListenerContext)contextObj;

            string requestUrl = context.Request.Url.AbsolutePath;
            string requestMethod = context.Request.HttpMethod;
            string ime = requestUrl.Substring(1);

            //Console.WriteLine($"Primljeno ime: {ime}");

            //Console.WriteLine($"Request: {requestMethod} {requestUrl}");

            //string query = "Paris";
            string day = "1";
            var apiService = new ApiService("https://api.weatherapi.com/v1/forecast.json", "03b77707127e4e6c916140528242404", day);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string lista;

            try
            {
                //LFU cache = new LFU(10); ne mozeeeeeeeeeeeeeeeeeeee
                string cacheRezultat = cache.Get(ime);
                if (cacheRezultat != null)
                {

                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(cacheRezultat);
                    context.Response.ContentLength64 = buffer.Length;
                    context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    context.Response.OutputStream.Close();
                    Console.WriteLine($"Grad {ime} vrednost je procitana iz Cache-a !");

                }

                else
                {
                    var result = apiService.FetchData(ime); // result je tipa JSON OBJ
                    lista = WeatherUtil.WriteResult(result); // lista je tipa string jer parsiramo JSON OBJ
                    cache.Put(ime, lista); // U KES ubacujemo ime grada kao kljuc hesa i parsiran string


                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(lista);
                    context.Response.ContentLength64 = buffer.Length;
                    context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    context.Response.OutputStream.Close();

                    Console.WriteLine($"Grad {ime} vrednost je pribavljena preko API-ja");

                }
                


                //Console.WriteLine($"Request {requestUrl} processed successfully");


                stopwatch.Stop();
                Console.WriteLine($"Vreme potrebno za izvrsenje je: {stopwatch.Elapsed}");

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }
    }
}
