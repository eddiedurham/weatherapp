using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class DayForecast
    {
        public DateTime Date { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public double HighTemperature { get; set; }
        public double LowTemperature { get; set; }
        public double Humidity { get; set; }
        public DateTime SunRise { get; set; }
        public DateTime SunSet { get; set; }
        public double WindBearing { get; set; }
        public double WindSpeed { get; set; }
        public double PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public double PrecipIntensity { get; set; }
        public double PrecipMaxIntensity { get; set; }
        public double AccumulatedPrecip { get; set; }
    }
}