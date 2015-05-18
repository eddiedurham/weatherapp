using ForecastIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace WeatherApp.OpenStreetMap
{
    public class NominatimRequest
    {
        private readonly string _q;
        private readonly string _street;
        private readonly string _city;
        private readonly string _county;
        private readonly string _state;
        private readonly string _country;
        private readonly string _postalCode;

        private const string QueryUrl = "http://nominatim.openstreetmap.org/search?format=json&polygon=0&addressdetails=0&limit=1&q={0}";
        private const string StructuredUrl = "http://nominatim.openstreetmap.org/search?format=json&polygon=0&addressdetails=0&limit=1";

        public NominatimRequest(string q)
        {
            this._q = q;
        }
        public NominatimRequest(string street, string city, string county, string state, string country, string postalCode)
        {
            this._street = street;
            this._city = city;
            this._county = county;
            this._state = state;
            this._country = country;
            this._postalCode = postalCode;
        }

        public NominatimResponse Get()
        {
            var url = "";
            if (!string.IsNullOrEmpty(this._q))
            {
                url = string.Format(QueryUrl, this._q);
            }
            else
            {
                string queryString = "";
                if (!string.IsNullOrEmpty(this._street))
                {
                    queryString += "&street=" + this._street;
                }
                if (!string.IsNullOrEmpty(this._city))
                {
                    queryString += "&city=" + this._city;
                }
                if (!string.IsNullOrEmpty(this._state))
                {
                    queryString += "&state=" + this._state;
                }
                if (!string.IsNullOrEmpty(this._postalCode))
                {
                    queryString += "&postalcode=" + this._postalCode;
                }

                url = StructuredUrl + queryString;
            }
            string result;
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                result = client.DownloadString(url);
            }
            var serializer = new JavaScriptSerializer();
            var dataObject = serializer.Deserialize<List<NominatimResponse>>(result);

            return dataObject[0];
        }
    }
}