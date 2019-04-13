using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventRegistration.Models
{
    public class RegistrationDay
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public int EventDayId { get; set; }

        public Day EventDay { get; set; }
        public Registration Registration { get; set; }

        public override string ToString()
        {
            return EventDay.Label.ToString();
        }
    }
}
