using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DateDiffMVC.Controllers;
using DateDiffMVC.Models;
using DateDiffMVC.Utilities;


namespace DateDiffMVC.ViewModels
{
    [HomeViewValidation]
    public class HomeViewModel
    {

    public int StartDay { get; set; }
    public int  StartMonth  { get; set; }
    public int StartYear { get; set; }
        //public Date StartDate { get; set; }
    public int EndDay { get; set; }
    public int EndMonth { get; set; }
    public int EndYear { get; set; }
        //public Date EndDate { get; set; }

        public string Result { get; set; }


    }
}