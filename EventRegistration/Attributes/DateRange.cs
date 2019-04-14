using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventRegistration.Attributes
{
    public class DateRange: ValidationAttribute
    {
        public object FirstDate { get; set; }
        public object SecondDate { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // your validation logic
            if (Convert.ToDateTime(value) >= Convert.ToDateTime(FirstDate) && Convert.ToDateTime(value) <= Convert.ToDateTime(SecondDate))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date is not in given range.");
            }
        }
    }
}
