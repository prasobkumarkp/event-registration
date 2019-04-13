using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventRegistration.Models
{
    public class ChecklistItem
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public bool Selected { get; set; }
        public string Value { get; set; }
    }
}
