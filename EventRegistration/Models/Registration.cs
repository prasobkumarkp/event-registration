using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventRegistration.Models
{
    public class Registration
    {
        [DisplayName("No"), Editable(false), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public User User { get; set; }
        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}"), DataType(DataType.Date)]
        // [Range(typeof(DateTime), "01/01/2019", "06/30/2019",ConvertValueInInvariantCulture = true)]
        public DateTime DateRegistered { get; set; }
        public int DayId { get; set; }
        [DataType(DataType.MultilineText)]
        public string AdditionalRequest { get; set; }

        public List<Day> SelectedDays { get; set; }
    }
}
