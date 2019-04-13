using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventRegistration.Models
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, DataType(DataType.Text), MaxLength(30)]
        public string Name { get; set; }
        [Required, DataType(DataType.EmailAddress), MaxLength(50)]
        public string EmailId { get; set; }
        public int GenderId { get; set; }

        [Required]
        public Gender Gender { get; set; }
        public ICollection<Registration> Registration { get; set; }
    }
}
