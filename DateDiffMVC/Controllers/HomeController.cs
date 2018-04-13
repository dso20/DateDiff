using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using DateDiffMVC.Models;
using DateDiffMVC.Services;
using DateDiffMVC.ViewModels;

namespace DateDiffMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalendarService _calendarService;
        private readonly ILoggerService _logger;

        public HomeController(ICalendarService calendarService,ILoggerService logger)
        {
            _calendarService = calendarService;
            _logger = logger;
        }

        [Route("Home/Index/")]
        public ActionResult Index()
        {
            return View(new HomeViewModel());
        }

        //to test how to mock the view model? do we even?
        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {

            if (!ModelState.IsValid)
                return View(new HomeViewModel());


            var result = _calendarService.Result(model.StartDate, model.EndDate);
            //below should go in the calendar service?
            _logger.Log($"The difference between these dates is {result.Item3} years {result.Item2} Months and {result.Item1} days.", this.GetType());
            
            var viewModel = new HomeViewModel() {Result = result };

            return View(viewModel);

        }

      //  [AcceptVerbs("Get", "Post")]
        public JsonResult VerifyTest(string Test)
        {
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}