using EventRegistration.Models;
using System.Collections.Generic;

namespace EventRegistration.ViewModels
{
    public class AddEventViewModel
    {
        public Registration Registration { get; set; }
        public List<ChecklistItem> EventDays { get; set; }
        public List<ChecklistItem> Genders { get; set; }
    }
}
