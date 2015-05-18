using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WeatherApp.OpenStreetMap
{
    public class NominatimResponse
    {
        public float lat;
        public float lon;

        public override string ToString()
        {
            return lat.ToString() + "," + lon.ToString();
        }
    }
}