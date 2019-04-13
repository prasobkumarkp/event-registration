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
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
