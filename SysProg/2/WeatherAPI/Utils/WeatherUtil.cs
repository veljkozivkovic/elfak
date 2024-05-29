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
                if (result == null || result.ContainsKey("error"))
                {
                    return "Upit nije dobro poslat";
                }

                double average_temp = CalculateAverageTemperature(result);


                string locationName = result["location"]["name"].ToString();
                string country = result["location"]["country"].ToString();
                string temp = result["current"]["temp_c"].ToString();
                string airq = result["current"]["air_quality"].ToString();
                string opis = result["current"]["condition"]["text"].ToString().ToLower();

                return $"{locationName} iz {country} je {opis} sa trenutnom temperaturom od {temp} stepeni celzijusa i srednjom dnevnom temperaturom od {average_temp:F2} stepeni celzijusa. \n Kvalitet vazduha: {airq} ";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static double CalculateAverageTemperature(JObject data)
        {
            try
            {

                List<double> temperatures = new List<double>();
                string targetDate = DateTime.Now.ToString("yyyy-MM-dd");

                foreach (var entry in data["forecast"]["forecastday"])
                {
                    string date = entry["date"].ToString();
                    if (date == targetDate)
                    {
                        foreach (var hourData in entry["hour"])
                        {
                            double temp = hourData["temp_c"].ToObject<double>();
                            temperatures.Add(temp);
                        }
                    }
                }

                if (temperatures.Count == 0)
                    throw new Exception("No temperature data found for the specified date.");

                double averageTemperature = temperatures.Average();
                return averageTemperature;
            }
            catch (Exception ex)
            {
                throw new Exception("Error calculating average temperature: " + ex.Message);
            }


        }
    }
}
