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
            return View(new Models.CurrentWeather());
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
            return View(new Models.WeekForecast());
        }
    }
}