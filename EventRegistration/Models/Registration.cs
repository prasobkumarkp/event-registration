using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}"), DataType(DataType.Date)]
        // [Range(typeof(DateTime), "01/01/2019", "06/30/2019",ConvertValueInInvariantCulture = true)]
        public DateTime DateRegistered { get; set; }
        [DataType(DataType.MultilineText)]
        public string AdditionalRequest { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<RegistrationDay> RegistrationDay { get; set; }
    }
}
