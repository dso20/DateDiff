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
            // _calendarService = DependencyResolver.Current.GetService<ICalendarService>();
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
            {
                return View(new HomeViewModel());
            }

            
       
            var days1 = _calendarService.ToDays(model.StartDate);
            var days2 = _calendarService.ToDays(model.EndDate);

            //find the difference
            var timespan = (new TimeSpan(days2, 0, 0, 0) - (new TimeSpan(days1, 0, 0, 0)));

            //turn that difference to days months years
            var result =  _calendarService.Diff(timespan.Days, model.StartDate);
            
            var strReturn = string.Format("There are {0} Years {1} Months and {2} Days between these dates.", result.Item3, result.Item2, result.Item1);
            ModelState.Remove("Result");
            var viewModel = new HomeViewModel() {Result = strReturn };

            return View(viewModel);

        }

    
    }

}