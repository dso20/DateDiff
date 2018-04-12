using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using DateDiffMVC.Models;
using DateDiffMVC.Services;
using DateDiffMVC.ViewModels;

//taking 1582 as our start point as modern calendars seem to backdate leap years
namespace DateDiffMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalendarService _calendarService;

        public HomeController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [Route("Home/Index/")]
        public ActionResult Index()
        {
            return View(new HomeViewModel());
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {

            if (!ModelState.IsValid)
                return View(new HomeViewModel());


            var result = _calendarService.Result(model.StartDate, model.EndDate);
            var viewModel = new HomeViewModel() {Result = result };

            return View(viewModel);

        }
    
    }

}