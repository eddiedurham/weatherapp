using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class Hourly
    {
        public int Hour { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public double Temperature { get; set; }
        public double ApparentTemperature { get; set; }
        public double Humidity { get; set; }
        public double WindBearing { get; set; }
        public double WindSpeed { get; set; }
        public double PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public double PrecipIntensity { get; set; }
    }
}