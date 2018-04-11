using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DateDiffMVC.Controllers;
using DateDiffMVC.Models;
using DateDiffMVC.Utilities;


namespace DateDiffMVC.ViewModels
{
    //q should i be newing up a date in here to pass to the controller?
    [HomeViewValidation]
    public class HomeViewModel : IHomeViewModel
    {
        
    public int StartDay { get; set; }
    public int  StartMonth  { get; set; }
        //[Range(1, int.MaxValue, ErrorMessage = "TEST")]
    public int StartYear { get; set; }

        //public Date StartDate { get; set; }
    public int EndDay { get; set; }
    public int EndMonth { get; set; }
    public int EndYear { get; set; }
        //public Date EndDate { get; set; }

        public string Result { get; set; }


    }
}