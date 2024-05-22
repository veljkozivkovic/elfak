using System;
using System.Net.Http;
using System.Threading;



namespace Klijent
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista sa imenima gradova
            List<string> gradovi = new List<string> { "Belgrade", "Moscow", "Zagreb", "Podgorica", "Paris", "Berlin", "Rome", "London" };

            // Kreiranje i pokretanje niti za svaki grad
            foreach (string grad in gradovi)
            {
                Thread requestThread = new Thread(() => SendRequest(grad));
                requestThread.Start();
            }

            // Čekanje da se sve niti završe
            Thread.Sleep(1000);
            Console.WriteLine("Svi zahtevi su poslati.");
        }

        static void SendRequest(string grad)
        {
            string url = $"http://localhost:5000/{grad}"; // Dodavanje imena grada u URL

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode(); // Provera da li je odgovor uspesan

                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Odgovor servera za grad {grad}:");
                    Console.WriteLine(responseBody);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Došlo je do greške prilikom slanja zahteva za grad {grad}: {ex.Message}");
                }
            }
        }

    }
}


//using System;
//using System.Net.Http;
//using System.Threading;



//namespace Klijent
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            while (true)
//            {
//                // Unos imena grada od strane korisnika
//                Console.WriteLine("Unesite ime grada ili 'exit' za izlaz:");
//                string grad = Console.ReadLine();

//                if (grad.ToLower() == "exit")
//                    break;

//                // Slanje HTTP zahteva sa imenom grada
//                SendRequest(grad);
//            }
//        }

//        static void SendRequest(string grad)
//        {
//            string url = $"http://localhost:5000/{grad}"; // Dodavanje imena grada u URL

//            using (HttpClient client = new HttpClient())
//            {
//                try
//                {
//                    HttpResponseMessage response = client.GetAsync(url).Result;
//                    response.EnsureSuccessStatusCode(); // Provera da li je odgovor uspešan

//                    string responseBody = response.Content.ReadAsStringAsync().Result;
//                    Console.WriteLine("Odgovor servera:");
//                    Console.WriteLine(responseBody);
//                }
//                catch (HttpRequestException ex)
//                {
//                    Console.WriteLine($"Došlo je do greške prilikom slanja zahteva: {ex.Message}");
//                }
//            }
//        }

//    }
//}