using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventRegistration.Attributes
{
    public class DateRange:RangeAttribute
    {
        public DateRange(double minimum, double maximum) : base(minimum, maximum)
        {
        }

        public DateRange(int minimum, int maximum) : base(minimum, maximum)
        {
        }

        public DateRange(Type type, string minimum, string maximum) : base(type, minimum, maximum)
        {
        }
    }
}
