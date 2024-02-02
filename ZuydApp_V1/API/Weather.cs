using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ZuydApp_V1.API
{
    public class Weather
    {
        public string Weatherdatetime { get; set; }
        public string Weatherdesc {  get; set; }
        public string WeatherMaxtemp { get; set; }
        public string WeatherMintemp { get; set; }

        private static List<Weather> forecast = new List<Weather>();

        public static async void URLWeather()
        {
            string WeatherKey = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/Kerkrade?unitGroup=metric&key=PJLUVWR4WGEDRA6PLYJ9W8E8E&contentType=json";
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"{WeatherKey}");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode(); // Throw an exception if error

            var body = await response.Content.ReadAsStringAsync(); // From the URL query code above 

            dynamic weather = JsonConvert.DeserializeObject(body);

            // Loop through every "day" in the JSON and print a few details
            foreach (var day in weather.days)
            {
                Weather newday = new Weather();
                newday.Weatherdatetime = day.datetime;
                newday.Weatherdesc = day.description;
                newday.WeatherMaxtemp = day.tempmax;
                newday.WeatherMintemp = day.tempmin;
                forecast.Add(newday);
            }
        }
        public static List<Weather> GetForecast()
        {
            return forecast;
        }
    }
}
