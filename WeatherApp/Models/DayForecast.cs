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
        public float HighTemperature { get; set; }
        public float LowTemperature { get; set; }
        public float Humidity { get; set; }
        public DateTime SunRise { get; set; }
        public DateTime SunSet { get; set; }
        public float WindBearing { get; set; }
        public string WindBearingIcon { get; set; }
        public float WindSpeed { get; set; }
        public float PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public float PrecipIntensity { get; set; }
        public float PrecipMaxIntensity { get; set; }
        public float AccumulatedPrecip { get; set; }

        public string HumidityFormat
        {
            get
            {
                return (Humidity * 100).ToString() + "%";
            }
        }
        public string PrecipProbabilityFormat
        {
            get
            {
                return (PrecipProbability * 100).ToString() + "%";
            }
        }

        public DayForecast(DateTime _date, string _summary, string _icon, float _highTemperature, float _lowTemperature, float _humidity, 
            DateTime _sunRise, DateTime _sunSet, float _windBearing, float _windspeed, float _precipProbability, string _precipType,
            float _precipIntensity, float _precipMaxIntensity, float _accumulatedPrecip)
        {
            this.Date = _date;
            this.Summary = _summary;
            this.Icon = Helper.Instance.GetIconName(_icon);
            this.HighTemperature = _highTemperature;
            this.LowTemperature = _lowTemperature;
            this.Humidity = _humidity;
            this.SunRise = _sunRise;
            this.SunSet = _sunSet;
            this.WindBearing = _windBearing;
            this.WindBearingIcon = Helper.Instance.GetDirectionIcon(this.WindBearing);
            this.WindSpeed = _windspeed;
            this.PrecipProbability = _precipProbability;
            this.PrecipType = _precipType;
            this.PrecipIntensity = _precipIntensity;
            this.PrecipMaxIntensity = _precipMaxIntensity;
            this.AccumulatedPrecip = _accumulatedPrecip;
        }
    }
}