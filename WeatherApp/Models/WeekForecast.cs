using ForecastIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class WeekForecast
    {
        public List<DayForecast> Week;

        public WeekForecast()
        {
            Week = new List<DayForecast>();
            var request = new ForecastIORequest("cd912c61ab0c9a4ccc75e7cf6f91adba", 37.3058333f, -89.5180556f, Unit.us);
            var response = request.Get();

            foreach (ForecastIO.DailyForecast d in response.daily.data)
            {
                DateTime Date = Helper.Instance.ConvertUNIXToLocalTime(d.time);
                DateTime SunRise = Helper.Instance.ConvertUNIXToLocalTime(d.sunriseTime);
                DateTime SunSet = Helper.Instance.ConvertUNIXToLocalTime(d.sunsetTime);
                DayForecast df = new DayForecast(Date, d.summary, d.icon, d.temperatureMax, d.temperatureMin, d.humidity,
                    SunRise, SunSet, d.windBearing, d.windSpeed, d.precipProbability, d.precipType, d.precipIntensity,
                    d.precipIntensityMax, d.precipAccumulation);

                Week.Add(df);
            }
        }
    }
}