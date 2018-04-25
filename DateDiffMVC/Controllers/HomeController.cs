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
#region Notes

//Tech/approches used in project
//Service layer
//Decorator pattern (see logging)
//Automation testing, using hooks
//Unit testing
//dependency injection using AutoFac, see global
//"decorator injection" as above
//SOLID principles
//custom validation
//object validation
//ajax valid dation using metadata (failing)
//razor inline helper, see index view
//to debud publish site to local iis, create website folder for it to run from, then push changes from here to that folder. You "attach" this to the process of the site running to debug, allowing to have the site constantly running
//to attach to prcoess W3W (iis one for each site). to get a list for the id, CMD as admin. cd inetsrv. appcmd list wp
#endregion
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