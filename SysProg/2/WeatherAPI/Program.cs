using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherAPI.LFUCache;
using WeatherAPI.Services;
using WeatherAPI.Utils;

namespace WeatherAPI
{
    public class Program
    {
        static async Task  Main(string[] args)
        {
            string url = "http://localhost:5000/";

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine("Server running at " + url);

            // Kreiranje cache-a
            LFU lfu = new LFU(3); //3 smo stavili da vidimo stvarno da li izbacuje
           
            string day = "1";
            var apiService = new ApiService("https://api.weatherapi.com/v1/forecast.json", "03b77707127e4e6c916140528242404", day);

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                //ovaj if smo stavili kako ne bismo nonstop imali warning za favicon
                if (context.Request.Url.AbsolutePath != "/favicon.ico")
                    await Task.Run(() => Handler.HandleRequestAsync(context, lfu, apiService));

            }


        }


        



    }
}
