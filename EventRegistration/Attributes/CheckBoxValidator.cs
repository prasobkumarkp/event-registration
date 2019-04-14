using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EventRegistration.Models;

namespace EventRegistration.Attributes
{
    public class CheckBoxValidator : ValidationAttribute
    {
        public object MinimumNumberOptionShouldBeSelected { get; set; }
 
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToInt32(MinimumNumberOptionShouldBeSelected) <= (value as List<ChecklistItem>)?.Select(s=>s.Selected)?.Count())
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"At least {MinimumNumberOptionShouldBeSelected} should be selected");
            }
        }
    }
}
