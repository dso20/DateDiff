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

    [HomeViewValidation] 
//REPLACE WITH OBJECT VALIDATION?
    public class HomeViewModel  
    {

        public Date StartDate { get; set; }
        public Date EndDate { get; set; }

        public Tuple<int,int,int> Result { get; set; }


        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
            
        //}
    }
}