using System.ComponentModel.DataAnnotations;

namespace FormApplication.Models
{
    public class PersonDto
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Company { get; set; } = "";
        [Required, MaxLength(100)]
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string ReasonForContact { get; set; } = "";
        public string? MoreDetails { get; set; }
    }
}
