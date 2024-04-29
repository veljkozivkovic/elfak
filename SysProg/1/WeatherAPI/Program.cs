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
using WeatherAPI.LFUCache;

namespace WeatherAPI
{
    public class Program
    {
        static  void Main(string[] args)
        {
            string url = "http://localhost:5000/";

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine("Server running at " + url);

            // Kreiranje instance tima LRU
            LFU lfu = new LFU(3); // Zamijenite ovaj kod sa stvarnom inicijalizacijom LRU tima

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                // Postavljanje obrade zahteva na ThreadPool-u, koristeći lambda izraz za prosleđivanje LRU tima
                if (context.Request.Url.AbsolutePath != "/favicon.ico")
                    ThreadPool.QueueUserWorkItem((state) => Handler.HandleRequest(context, lfu));
            }


        }


        



    }
}
