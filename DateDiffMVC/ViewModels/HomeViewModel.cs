using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateDiffMVC.Controllers;
using DateDiffMVC.Models;
using DateDiffMVC.Utilities;


namespace DateDiffMVC.ViewModels
{

    // [HomeViewValidation] 
    //REPLACEd WITH OBJECT VALIDATION
    [MetadataType(typeof(Metadata))]
    public class HomeViewModel  : IValidatableObject
    {

        public Date StartDate { get; set; }
        public Date EndDate { get; set; }

      //  public string test { get; set; }

        public Tuple<int,int,int> Result { get; set; }

        [Remote("VerifyTest", "Home", ErrorMessage = "TEST")]
        public string Test { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool valid = StartDate.Year <= EndDate.Year;

            if (!valid && StartDate.Year != EndDate.Year)
            {
                yield return new ValidationResult("Start year is in the past");
                yield break;
            }

            if (valid && StartDate.Year == EndDate.Year)
            {
                valid = StartDate.Month <= EndDate.Month;
            }

            if (valid && StartDate.Month == EndDate.Month && StartDate.Year == EndDate.Year)
            {
                valid = StartDate.Day < EndDate.Day;
            }

            yield return valid ? ValidationResult.Success : new ValidationResult("Start date is in the past");

        }
    }

}