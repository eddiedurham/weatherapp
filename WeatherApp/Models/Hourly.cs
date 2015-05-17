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
        public float Temperature { get; set; }
        public float ApparentTemperature { get; set; }
        public float Humidity { get; set; }
        public float WindBearing { get; set; }
        public string WindBearingIcon{get;set;}
        public float WindSpeed { get; set; }
        public float PrecipProbability { get; set; }
        public string PrecipType { get; set; }
        public float PrecipIntensity { get; set; }

        public string HourFormat
        {
            get
            {
                if (Hour < 12)
                {
                    if (Hour == 0) Hour = 12;

                    return Hour.ToString() + " AM";
                }
                else
                {
                    int temp = Hour % 12;
                    if (temp == 0) temp = 12;

                    return temp.ToString() + " PM";
                }
            }
        }

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

        public Hourly(int _hour, string _summary, string _icon, float _temperature, 
            float _apparentTemperature, float _humidity, float _windBearing, float _windSpeed, float _precipProbabilty,
            string _precipType, float _precipIntensity)
        {
            this.Hour = _hour;
            this.Summary = _summary;
            this.Icon = Helper.Instance.GetIconName(_icon);
            this.Temperature = _temperature;
            this.ApparentTemperature = _apparentTemperature;
            this.Humidity = _humidity;
            this.WindBearing = _windBearing;
            this.WindBearingIcon = Helper.Instance.GetDirectionIcon(this.WindBearing);
            this.WindSpeed = _windSpeed;
            this.PrecipProbability = _precipProbabilty;
            this.PrecipType = _precipType;
            this.PrecipIntensity = _precipIntensity;
        }
    }
}