using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventRegistration.Attributes;


namespace EventRegistration.Models
{
    public class Registration
    {
        public Registration()
        {
            RegistrationDay = new HashSet<RegistrationDay>();
        }

        [DisplayName("No"), Editable(false), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Date registered")]
        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Range(typeof(DateTime), "01/01/2019", "06/30/2019", ErrorMessage = "Value for {0} must be between {1:d} and {2:d}")]
        public DateTime DateRegistered { get; set; }

        [MaxLength(100), DisplayName("Additional request"), DataType(DataType.MultilineText),]
        public string AdditionalRequest { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
        [DisplayName("Selected Days")]
        public ICollection<RegistrationDay> RegistrationDay { get; set; }
    }
}
