using ForecastIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.OpenStreetMap;

namespace WeatherApp.Models
{
    public class CurrentWeather
    {
        public string Summary { get; set; }
        public float Temperature { get; set; }
        public float ApparentTemperature { get; set; }
        public float Humidity { get; set; }
        public string Icon { get; set; }
        public string PrecipType { get; set; }
        public float PrecipProbability { get; set; }
        public float PrecipIntensity { get; set; }
        public float WindBearing { get; set; }
        public string WindBearingIcon { get; private set; }
        public float WindSpeed { get; set; }
        public float NearestStormBearing { get; set; }
        public string NearestStormBearingIcon { get; private set; }
        public float NearestStormDistance { get; set; }
        public HourlyForecast Hourly { get; set; }

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

        public CurrentWeather()
        {
            var request = new ForecastIORequest("cd912c61ab0c9a4ccc75e7cf6f91adba", 37.3058333f, -89.5180556f, Unit.us);
            var response = request.Get();

            this.Summary = response.currently.summary;
            this.Temperature = response.currently.temperature;
            this.ApparentTemperature = response.currently.apparentTemperature;
            this.Humidity = response.currently.humidity;
            this.Icon = Helper.Instance.GetIconName(response.currently.icon);
            this.PrecipType = response.currently.precipType;
            this.PrecipProbability = response.currently.precipProbability;
            this.PrecipIntensity = response.currently.precipIntensity;
            this.WindBearing = response.currently.windBearing;
            this.WindBearingIcon = Helper.Instance.GetDirectionIcon(this.WindBearing);
            this.WindSpeed = response.currently.windSpeed;
            this.NearestStormBearing = response.currently.nearestStormBearing;
            this.NearestStormBearingIcon = Helper.Instance.GetDirectionIcon(this.NearestStormBearing);
            this.NearestStormDistance = response.currently.nearestStormDistance;

            this.Hourly = new HourlyForecast(response.hourly);

            var nomRequest = new NominatimRequest("", "", "", "", "", "63703");
            var nomResponse = nomRequest.Get();

            //this.Summary = "Rainy";
            //this.Temperature = 70f;
            //this.ApparentTemperature = 70f;
            //this.Humidity = .90f;
            //this.Icon = "wi-day-rain";
            //this.PrecipType = "rain";
            //this.PrecipProbability = 1f;
            //this.PrecipIntensity = .1f;
            //this.WindBearing = 270f;
            //this.WindSpeed = 5f;
            //this.NearestStormBearing = 270f;
            //this.NearestStormDistance = 100f;
        }
    }
}