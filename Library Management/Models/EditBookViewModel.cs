using System.ComponentModel.DataAnnotations;

namespace Library_Management.Models
{
    public class EditMovieViewModel
    {
        [Required(ErrorMessage = "Movie ID is required.")]
        public Guid MovieId { get; set; }

        [Required(ErrorMessage = "Movie title is required.")]
        [Display(Name = "Movie Title")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [Display(Name = "Genre")]
        public string? Genre { get; set; }

        [Required(ErrorMessage = "Release date is required.")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Runtime is required.")]
        [Range(1, 999, ErrorMessage = "Runtime must be between 1 and 999 minutes")]
        [Display(Name = "Runtime (minutes)")]
        public int Runtime { get; set; }

        [Display(Name = "Trailer URL")]
        public string? TrailerUrl { get; set; }

        [Required(ErrorMessage = "Poster URL is required.")]
        [Display(Name = "Poster Image URL")]
        public string? PosterUrl { get; set; }

        [Display(Name = "Backdrop Image URL")]
        public string? BackdropUrl { get; set; }

        [Required(ErrorMessage = "Language is required.")]
        [Display(Name = "Language")]
        public string? Language { get; set; }

        [Display(Name = "Country")]
        public string? Country { get; set; }

        [Display(Name = "Content Rating")]
        public string? ContentRating { get; set; }

        [Display(Name = "Featured Movie")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Trending Movie")]
        public bool IsTrending { get; set; }

        public Guid? DirectorId { get; set; }

        [Required(ErrorMessage = "Director name is required.")]
        [Display(Name = "Director Name")]
        public string? DirectorName { get; set; }

        [Display(Name = "Director Biography")]
        public string? DirectorBiography { get; set; }

        [Display(Name = "Director Profile Image URL")]
        public string? DirectorProfileImageUrl { get; set; }

        [Display(Name = "Director Nationality")]
        public string? DirectorNationality { get; set; }
    }
}
