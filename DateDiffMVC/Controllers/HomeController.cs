using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using DateDiffMVC.Models;
using DateDiffMVC.ViewModels;

//taking 1582 as our start point as modern calendars seem to backdate leap years
namespace DateDiffMVC.Controllers
{
    public class HomeController : Controller
    {
        //q do we want to break the dependency to date? if so customerFactoryController?
        //q do we want to break the dependency to viewModels?
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
            
            var days1 = Date.ToDays(new Date(model.StartDay, model.StartMonth, model.StartYear));
            var days2 = Date.ToDays(new Date(model.EndDay, model.EndMonth, model.EndYear));

            //find the difference
            var timespan = (new TimeSpan(days2, 0, 0, 0) - (new TimeSpan(days1, 0, 0, 0)));

            //turn that difference to days months years
            var result =  Date.Diff(timespan.Days, new Date(model.StartYear,model.StartMonth,model.StartDay));
            
            var strReturn = string.Format("There are {0} Years {1} Months and {2} Days between these dates.", result.Item3, result.Item2, result.Item1);
            ModelState.Remove("Result");
            var viewModel = new HomeViewModel() {Result = strReturn };

            return View(viewModel);

        }

    
    }



}