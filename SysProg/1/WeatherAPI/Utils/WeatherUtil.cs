using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherAPI.Utils
{
    public class WeatherUtil
    {
        public static string WriteResult(JObject result)
        {

            try
            {
                if (result.ContainsKey("error"))
                {
                    return "Upit nije dobro poslat";
                }

                string locationName = result["location"]["name"].ToString();
                string country = result["location"]["country"].ToString();
                string temp = result["current"]["temp_c"].ToString();
                string airq = result["current"]["air_quality"].ToString();
                string opis = result["current"]["condition"]["text"].ToString().ToLower();

                return $"{locationName} iz {country} je {opis} sa temperaturom od {temp} stepeni celzijusa {airq} ";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
