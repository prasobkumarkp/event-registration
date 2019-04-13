using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRegistration.Models
{
    public class Day
    {
        public Day()
        {
            RegistrationDays = new HashSet<RegistrationDay>();
        }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Day")]
        public string Label { get; set; }

        public ICollection<RegistrationDay> RegistrationDays { get; set; }

        public override string ToString()
        {
            return Label;
        }
    }
}
