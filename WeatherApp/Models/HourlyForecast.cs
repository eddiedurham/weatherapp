using ForecastIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class HourlyForecast
    {
        public List<Hourly> Forecast;

        public HourlyForecast()
        {
            Forecast = new List<Hourly>();

            var request = new ForecastIORequest("cd912c61ab0c9a4ccc75e7cf6f91adba", 37.3058333f, -89.5180556f, Unit.us);
            var response = request.Get();

            int hour = DateTime.Now.Hour;

            for (int i = 0; i < 24; i++)
            {
                ForecastIO.HourForecast hf = response.hourly.data[i];
                DateTime t = Helper.Instance.ConvertUNIXToLocalTime(hf.time);
                Hourly h = new Hourly(t.Hour, hf.summary, hf.icon, hf.temperature, hf.apparentTemperature, hf.humidity, hf.windBearing, hf.windSpeed, hf.precipProbability, hf.precipType, hf.precipIntensity);
                Forecast.Add(h);
            }
        }

        public HourlyForecast(ForecastIO.Hourly forecast)
        {
            Forecast = new List<Hourly>();

            for (int i = 0; i < 24; i++)
            {
                ForecastIO.HourForecast hf = forecast.data[i];
                DateTime t = Helper.Instance.ConvertUNIXToLocalTime(hf.time);
                Hourly h = new Hourly(t.Hour, hf.summary, hf.icon, hf.temperature, hf.apparentTemperature, hf.humidity, hf.windBearing, hf.windSpeed, hf.precipProbability, hf.precipType, hf.precipIntensity);
                Forecast.Add(h);
            }
        }
    }
}