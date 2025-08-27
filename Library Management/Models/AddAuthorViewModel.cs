using System.ComponentModel.DataAnnotations;

namespace Library_Management.Models
{
    public class AddAuthorViewModel
    {
        [Required(ErrorMessage = "Author name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Biography cannot exceed 1000 characters")]
        public string? Biography { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Profile Image URL")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string? ProfileImageUrl { get; set; }
    }
}
