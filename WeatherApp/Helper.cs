using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp
{
    public class Helper
    {
        private static Helper _instance;
        public static Helper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Helper();
                }
                return _instance;
            }
        }

        protected Helper() { }

        public string GetIconName(string value)
        {
            string result = "";
            switch (value)
            {
                case "clear-day":
                    result = "wi-day-sunny";
                    break;
                case "clear-night":
                    result = "wi-night-clear";
                    break;
                case "rain":
                    result = "wi-rain";
                    break;
                case "snow":
                    result = "wi-snow";
                    break;
                case "sleet":
                    result = "wi-sleet";
                    break;
                case "wind":
                    result = "wi-strong-wind";
                    break;
                case "fog":
                    result = "wi-fog";
                    break;
                case "cloudy":
                    result = "wi-cloudy";
                    break;
                case "partly-cloudy-day":
                    result = "wi-day-sunny-overcast";
                    break;
                case "partly-cloudy-night":
                    result = "night-partly-cloudy";
                    break;
                default:
                    result = "wi-alien";
                    break;
            }
            return result;
        }

        public string GetDirectionIcon(float direction)
        {
            int roundedDirection = Convert.ToInt32(Math.Round(direction));
            int dirMod = roundedDirection % 15;
            
            if (dirMod > 7)
            {
                roundedDirection += (15 - dirMod);
                roundedDirection = roundedDirection % 360;
            }
            else
            {
                roundedDirection -= dirMod;
            }

            roundedDirection = (roundedDirection + 180) % 360;

            string result = "wi-wind-default _" + roundedDirection.ToString() + "-deg";

            return result;

        }

        public DateTime ConvertUNIXToLocalTime(long ticks)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(ticks).ToLocalTime();
            return dtDateTime;
        }
    }
}