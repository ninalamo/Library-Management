namespace Library_Management.Models
{
    public class MovieListViewModel
    {
        public Guid MovieId { get; set; }
        public string? Title { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public string? Genre { get; set; } = default!;
        public DateTime? ReleaseDate { get; set; } = default!;
        public int Runtime { get; set; }
        public string? TrailerUrl { get; set; } = default!;
        public string? PosterUrl { get; set; } = default!;
        public string? BackdropUrl { get; set; } = default!;
        public string? Language { get; set; } = default!;
        public string? Country { get; set; } = default!;
        public string? ContentRating { get; set; } = default!;
        public bool IsFeatured { get; set; }
        public bool IsTrending { get; set; }

        public string? DirectorName { get; set; } = default!;
        public string? DirectorProfileImageUrl { get; set; } = default!;
        public List<string> ActorNames { get; set; } = [];
        public double AverageRating { get; set; } = 0.0;
        public int TotalRatings { get; set; } = 0;
        public int TotalComments { get; set; } = 0;
        public string FormattedRuntime => $"{Runtime / 60}h {Runtime % 60}m";
    }

    public class MovieDetailsViewModel
    {
        public Guid MovieId { get; set; }
        public string? Title { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public string? Genre { get; set; } = default!;
        public DateTime? ReleaseDate { get; set; } = default!;
        public int Runtime { get; set; }
        public string? TrailerUrl { get; set; } = default!;
        public string? PosterUrl { get; set; } = default!;
        public string? BackdropUrl { get; set; } = default!;
        public string? Language { get; set; } = default!;
        public string? Country { get; set; } = default!;
        public string? ContentRating { get; set; } = default!;
        public bool IsFeatured { get; set; }
        public bool IsTrending { get; set; }

        public List<DirectorViewModel> Directors { get; set; } = [];
        public List<ActorViewModel> Actors { get; set; } = [];
        public List<RatingViewModel> Ratings { get; set; } = [];
        public List<CommentViewModel> Comments { get; set; } = [];
        public double AverageRating { get; set; } = 0.0;
        public int TotalRatings { get; set; } = 0;
        public string FormattedRuntime => $"{Runtime / 60}h {Runtime % 60}m";
        public List<MovieListViewModel> SuggestedMovies { get; set; } = [];
    }

    public class DirectorViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = default!;
        public string? Biography { get; set; } = default!;
        public string? ProfileImageUrl { get; set; } = default!;
        public string? Nationality { get; set; } = default!;
    }

    public class ActorViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = default!;
        public string? Character { get; set; } = default!;
        public string? ProfileImageUrl { get; set; } = default!;
        public string? Nationality { get; set; } = default!;
        public int Order { get; set; }
    }

    public class RatingViewModel
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; } = default!;
        public int RatingValue { get; set; }
        public DateTime? CreatedDate { get; set; } = default!;
    }

    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; } = default!;
        public string? Text { get; set; } = default!;
        public DateTime? CreatedDate { get; set; } = default!;
        public DateTime? UpdatedDate { get; set; } = default!;
        public List<CommentViewModel> Replies { get; set; } = [];
    }
}
