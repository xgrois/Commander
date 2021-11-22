using System.ComponentModel.DataAnnotations;

namespace Commander.DTOs
{
    public class CommandCreateDTO
    {
        [Required]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        [MaxLength(250)]
        public string Platform { get; set; }
    }
}