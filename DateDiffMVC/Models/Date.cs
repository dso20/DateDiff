using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace DateDiffMVC.Models
{
    // arguably days in a date would make senes if it was a prop in here, just depends if we really don;t like logic in here...?
    //conversely days in a date are reliant on a calendar...?
  [MetadataType(typeof(Metadata))] //this or the JS related to it is stopping the submit
    public partial class Date :  IDate
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a year")]
        public int Year { get;  set; }
        [Required]
        [Range(1, 12, ErrorMessage = "Select a month")]
        public int Month { get;  set; }
        [Required]
        [Range(1,31, ErrorMessage = "Select a Day")]
        public int Day { get; set; }



        //Q Whether a year is a leap year and how many days in a month could be considered props of a date (especially leap year)
        //but if logic shouldn't go in here thne it needs to go in service
        

      
        [Remote(action: "VerifyTest", controller: "Home", ErrorMessage = "TEST")]
        public string Test { get; set; }
    }

    public class Metadata
    {
        [Remote("VerifyTest", "Home", ErrorMessage = "TEST")]
        public string Test { get; set; }
    }



}