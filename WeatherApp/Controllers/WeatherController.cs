using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Current()
        {
            if (HttpContext.Request.Cookies["wLocation"] == null)
            {
                return RedirectToAction("LocationSearch");
            }

            string[] latLon = HttpContext.Request.Cookies.Get("wLocation").Value.Split(',');

            float lat = float.Parse(latLon[0]);
            float lon = float.Parse(latLon[1]);
            return View(new Models.CurrentWeather(lat, lon));
        }
        public ActionResult HourlyForecast()
        {
            Models.HourlyForecast model = new Models.HourlyForecast();
            return PartialView("_HourlyForecast", model);
        }
        public ActionResult Hourly()
        {
            Models.HourlyForecast model = new Models.HourlyForecast();
            return PartialView("_Hourly", model);
        }

        public ActionResult Forecast()
        {
            if (HttpContext.Request.Cookies["wLocation"] == null)
            {
                return RedirectToAction("LocationSearch");
            }

            string[] latLon = HttpContext.Request.Cookies.Get("wLocation").Value.Split(',');

            float lat = float.Parse(latLon[0]);
            float lon = float.Parse(latLon[1]);
            return View(new Models.WeekForecast(lat, lon));
        }
        public ActionResult LocationSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindLocation(Models.OpenStreetMap search)
        {
            try
            {
                OpenStreetMap.NominatimRequest request = new OpenStreetMap.NominatimRequest(search.Street, search.City, "", search.State, "", search.PostalCode);
                var response = request.Get();


                HttpCookie cookie = new HttpCookie("wLocation", response.ToString());
                Response.SetCookie(cookie);
                return RedirectToAction("Current", "Weather");
            }
            catch (Exception ex)
            {
                return RedirectToAction("LocationError");
            }
        }
        [Route("Weather/{PostalCode}/Current")]
        public ActionResult Current(string PostalCode)
        {
            OpenStreetMap.NominatimRequest request = new OpenStreetMap.NominatimRequest("", "", "", "", "", PostalCode);
            var response = request.Get();

            return View(new Models.CurrentWeather(response.lat, response.lon));
        }
        [Route("Weather/{PostalCode}/Forecast")]
        public ActionResult Forecast(string PostalCode)
        {
            OpenStreetMap.NominatimRequest request = new OpenStreetMap.NominatimRequest("", "", "", "", "", PostalCode);
            var response = request.Get();

            return View(new Models.WeekForecast(response.lat, response.lon));
        }
        [Route("Weather/random/Current")]
        public ActionResult CurrentRandom()
        {
            float[] latlon = Helper.Instance.RandomLatLon();

            return View("Current", new Models.CurrentWeather(latlon[0], latlon[1]));
        }
        [Route("Weather/random/Forecast")]
        public ActionResult ForecastRandom()
        {
            float[] latlon = Helper.Instance.RandomLatLon();

            return View("Forecast", new Models.WeekForecast(latlon[0], latlon[1]));
        }

        public ActionResult LocationError()
        {
            return View();
        }
    }
}