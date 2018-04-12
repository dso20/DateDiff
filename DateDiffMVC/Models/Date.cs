using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace DateDiffMVC.Models
{
    // arguably days in a date would make senes if it was a prop in here, just depends if we really don;t like logic in here...?
    //conversely days in a date are reliant on a calendar...?
    public class Date : IDate
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a year")]
        public int Year { get;  set; }
        [Required]
        [Range(1, 12, ErrorMessage = "Select a month")]
        public int Month { get;  set; }
        [Required]
        [Range(1, 31, ErrorMessage = "Select a day")]
        public int Day { get;  set; }


        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    throw new NotImplementedException();
        //}
    }

}