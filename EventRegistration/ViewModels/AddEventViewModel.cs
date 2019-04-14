using EventRegistration.Models;
using System.Collections.Generic;
using EventRegistration.Attributes;

namespace EventRegistration.ViewModels
{
    public class AddEventViewModel
    {
        public Registration Registration { get; set; }

        [CheckBoxValidator(MinimumNumberOptionShouldBeSelected = 1)]
        public List<ChecklistItem> EventDays { get; set; }

        public List<ChecklistItem> Genders { get; set; }
    }
}
