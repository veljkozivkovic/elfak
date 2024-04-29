using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Domain
{
    public class WeatherForecast
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Temperature { get; set; }
        public string AirQuality { get; set; }
        public string Opis { get; set; }

    }
}
