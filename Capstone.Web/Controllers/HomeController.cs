using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;
        private ISurveyDAO surveyDAO;

        public HomeController(IParkDAO parkDAO, IWeatherDAO weatherDAO, ISurveyDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
            this.surveyDAO = surveyDAO;
        }
    
        public IActionResult Index()
        {
            IList<Park> parks = parkDAO.GetAllParks();
            return View(parks);
        }
        
        [HttpGet]
        public IActionResult Detail(string parkCode)
        {
            if(!HttpContext.Session.Keys.Contains("temp"))
            {
                HttpContext.Session.SetString("temp", "f");
            }

            TempData["temp"] = HttpContext.Session.GetString("temp");

            Park park = parkDAO.GetParkDetail(parkCode);
            List<Weather> fiveDay = weatherDAO.GetFiveDayForecast(parkCode);


            DetailViewModel model = new DetailViewModel();
            model.Park = parkDAO.GetParkDetail(parkCode);
            model.FiveDayForecast = weatherDAO.GetFiveDayForecast(parkCode);

            if (HttpContext.Session.GetString("temp") == "f")
            {
                model.isFahrenheit = true;
            }
            else
            {
                model.isFahrenheit = false;
            }

            model.Park = park;

            // model.TempSetting 


            return View(model);
        }

        [HttpPost]
        public IActionResult Detail(string parkCode, string temp)
        {
            if (!HttpContext.Session.Keys.Contains("temp"))
            {
                HttpContext.Session.SetString("temp", "f");
            }

            if (temp != HttpContext.Session.GetString("temp"))
            {
                HttpContext.Session.SetString("temp", temp);
            }

            Park park = parkDAO.GetParkDetail(parkCode);
            List<Weather> weathers = weatherDAO.GetFiveDayForecast(parkCode);

            DetailViewModel model = new DetailViewModel();
            model.Park = parkDAO.GetParkDetail(parkCode);
            model.FiveDayForecast = weatherDAO.GetFiveDayForecast(parkCode);
            // model.TempSetting 
            if (HttpContext.Session.GetString("temp") == "f")
            {
                model.isFahrenheit = true;
            }
            else
            {
                model.isFahrenheit = false;
            }

            model.Park = park;


            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
