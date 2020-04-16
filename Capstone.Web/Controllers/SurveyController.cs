using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private IParkDAO parkDAO;
        private IWeatherDAO weatherDAO;
        private ISurveyDAO surveyDAO;

        public SurveyController(IParkDAO parkDAO, IWeatherDAO weatherDAO, ISurveyDAO surveyDAO)
        {
            this.parkDAO = parkDAO;
            this.weatherDAO = weatherDAO;
            this.surveyDAO = surveyDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewSurvey()
        {
            //IList<Park> parks = parkDAO.GetAllParks();
            Survey survey = new Survey();

            // vm.Parks 
            //survey.Parks = new SelectList(parks, "ParkCode", "ParkName");
            return View(survey);
        }

        [HttpPost]
        public ActionResult NewSurvey(Survey newSurvey)
        {
            surveyDAO.SaveSurvey(newSurvey);

            return RedirectToAction("SurveyResponse");
        }

        public ActionResult SurveyResponse()
        {
            List<SurveyResponse> surveys = surveyDAO.GetTopParks();


            return View(surveys);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}