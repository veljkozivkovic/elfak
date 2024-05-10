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
        static  void Main(string[] args)
        {
            string url = "http://localhost:5000/";

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine("Server running at " + url);

            // Kreiranje cache-a
            LFU lfu = new LFU(3); //3 smo stavili da vidimo stvarno da li izbacuje

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                //ovaj if smo stavili kako ne bismo nonstop imali warning za favicon
                if (context.Request.Url.AbsolutePath != "/favicon.ico")
                    ThreadPool.QueueUserWorkItem((state) => Handler.HandleRequest(context, lfu));
                // mora ovako sa lambda izrazom jer handlerequest ima sad 2 parametra...

            }


        }


        



    }
}
