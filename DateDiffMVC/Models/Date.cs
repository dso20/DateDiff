using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace DateDiffMVC.Models
{
    // arguably days in a date would make senes if it was a prop in here, just depends if we really don;t like logic in here...?
    //conversely days in a date are reliant on a calendar...?
 // [MetadataType(typeof(Metadata))] //this or the JS related to it is stopping the submit
    public partial class Date :  IDate
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a year")]
        public int Year { get;  set; }
        [Required]
        [Range(1, 12, ErrorMessage = "Select a month")]
        public int Month { get;  set; }
        // [Required]
        // [Range(1, 31, ErrorMessage = "Select a day")]
        //[Remote(action: "VerifyDay", controller: "Home", ErrorMessage = "TEST")]
        public int Day { get; set; }
    }

    public class Metadata
    {
        [Remote("VerifyDay", "Home", ErrorMessage = "TEST")]
        public int Day { get; set; }
    }



}