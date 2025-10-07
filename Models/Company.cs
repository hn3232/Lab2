// I, Hamdan Nadeem student number 000898704, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        [Display(Name = "Company Name")]
        [StringLength(200, ErrorMessage = "Company name cannot exceed 200 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Years in business is required.")]
        [Range(0, 1000, ErrorMessage = "Years in business must be between 0 and 1000.")]
        [Display(Name = "Years in Business")]
        public int YearsInBusiness { get; set; }

        [Required(ErrorMessage = "Website is required.")]
        [Url(ErrorMessage = "Please enter a valid URL (including http/https).")]
        [Display(Name = "Website")]
        [StringLength(300, ErrorMessage = "Website URL cannot exceed 300 characters.")]
        public string Website { get; set; } = string.Empty;
        [Display(Name = "Province")]
        [StringLength(100, ErrorMessage = "Province cannot exceed 100 characters.")]
        public string? Province { get; set; }
    }
}