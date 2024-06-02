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
        public static async Task HandleRequestAsync(object contextObj, LFU cache, ApiService apiService)
        {
            HttpListenerContext context = (HttpListenerContext)contextObj;

            string requestUrl = context.Request.Url.AbsolutePath;
            string requestMethod = context.Request.HttpMethod;
            string ime = requestUrl.Substring(1);

            //string day = "1";
            //var apiService = new ApiService("https://api.weatherapi.com/v1/forecast.json", "03b77707127e4e6c916140528242404", day);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string lista = ""; // moramo da inicijalizujemo kao prazan string zbog upita kasnije za stopwatch

            try
            {
                string cacheRezultat = cache.Get(ime);
                if (cacheRezultat != null)
                {
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(cacheRezultat);
                    context.Response.ContentLength64 = buffer.Length;
                    context.Response.ContentType = "text/plain; charset=utf-8"; // da pise latinicu
                    await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    Console.WriteLine($"Grad {ime} vrednost je procitana iz Cache-a !");
                }
                else
                {
                    var result = await apiService.FetchDataAsync(ime); // result je tipa JSON OBJ
                    lista = WeatherUtil.WriteResult(result); // lista je tipa string jer parsiramo JSON OBJ

                    if (lista.Equals("Upit nije dobro poslat"))
                        Console.WriteLine("Upit nije dobro poslat");
                    else
                    {
                        cache.Put(ime, lista); // U KES ubacujemo ime grada kao kljuc hesa i parsiran string
                        Console.WriteLine($"Grad {ime} vrednost je pribavljena preko API-ja");
                    }

                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(lista);
                    context.Response.ContentLength64 = buffer.Length;
                    context.Response.ContentType = "text/plain; charset=utf-8"; // da pise latinicu
                    await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    context.Response.OutputStream.Close();
                }

                stopwatch.Stop();

                //ne treba nam stoperica prilikom greske pisanja upita
                if (!lista.Equals("Upit nije dobro poslat"))
                {
                    Console.WriteLine($"Vreme potrebno za izvrsenje je: {stopwatch.Elapsed}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                context.Response.OutputStream.Close();
            }
        }



        }
}

