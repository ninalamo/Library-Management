using System.ComponentModel.DataAnnotations;

namespace Library_Management.Models
{
    public class AddMovieViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; } = default!;
        
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; } = default!;
        
        [Required(ErrorMessage = "Genre is required")]
        public string? Genre { get; set; } = default!;
        
        [Required(ErrorMessage = "Release date is required")]
        public DateTime? ReleaseDate { get; set; } = default!;
        
        [Required(ErrorMessage = "Runtime is required")]
        [Range(1, 999, ErrorMessage = "Runtime must be between 1 and 999 minutes")]
        public int Runtime { get; set; }
        
        public string? TrailerUrl { get; set; } = default!;
        
        [Required(ErrorMessage = "Poster URL is required")]
        public string? PosterUrl { get; set; } = default!;
        
        public string? BackdropUrl { get; set; } = default!;
        
        [Required(ErrorMessage = "Language is required")]
        public string? Language { get; set; } = default!;
        
        public string? Country { get; set; } = default!;
        public string? ContentRating { get; set; } = default!;
        public bool IsFeatured { get; set; }
        public bool IsTrending { get; set; }

        [Required(ErrorMessage = "Director name is required")]
        public string? DirectorName { get; set; } = default!;
        
        public string? DirectorBiography { get; set; } = default!;
        public string? DirectorProfileImageUrl { get; set; } = default!;
        public string? DirectorNationality { get; set; } = default!;

        public List<string> ActorNames { get; set; } = [];
        public List<string> ActorCharacters { get; set; } = [];
    }

    public class RateMovieViewModel
    {
        [Required]
        public Guid MovieId { get; set; }
        
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; set; } = default!;
        
        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 stars")]
        public int RatingValue { get; set; }
    }

    public class AddCommentViewModel
    {
        [Required]
        public Guid MovieId { get; set; }
        
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; set; } = default!;
        
        [Required(ErrorMessage = "Comment text is required")]
        [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters")]
        public string? Text { get; set; } = default!;
        
        public Guid? ParentCommentId { get; set; }
    }
}
