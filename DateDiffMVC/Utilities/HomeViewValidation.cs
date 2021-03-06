﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DateDiffMVC.ViewModels;

namespace DateDiffMVC.Utilities
{
    //redundant used a IValidatableObject Instead in the viewModel
    public class HomeViewValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (HomeViewModel)validationContext.ObjectInstance; //cast object from form to model type

            bool valid = context.StartDate.Year <= context.EndDate.Year;

            if (!valid && context.StartDate.Year != context.EndDate.Year)
            {
                return new ValidationResult("Start year is in the past");
            }

            if (valid && context.StartDate.Year == context.EndDate.Year)
            {
                valid = context.StartDate.Month <= context.EndDate.Month;
            }

            if (valid && context.StartDate.Month == context.EndDate.Month && context.StartDate.Year == context.EndDate.Year)
            {
                valid = context.StartDate.Day < context.EndDate.Day;
            }

            return valid ? ValidationResult.Success : new ValidationResult("Start date is in the past");

        }

    }
}

