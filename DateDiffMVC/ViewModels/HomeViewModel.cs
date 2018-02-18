using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DateDiffMVC.Controllers;
using DateDiffMVC.Models;
using DateDiffMVC.Utilities;


namespace DateDiffMVC.ViewModels
{[HomeViewValidation]
    public class HomeViewModel
    {


        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public string Result { get; set; }


    }
}