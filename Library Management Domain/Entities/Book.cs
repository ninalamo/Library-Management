using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_Domain.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string? Title { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public string? Genre { get; set; } = default!;
        public DateTime? ReleaseDate { get; set; } = default!;
        public int Runtime { get; set; } // in minutes
        public string? TrailerUrl { get; set; } = default!;
        public string? PosterUrl { get; set; } = default!;
        public string? BackdropUrl { get; set; } = default!;
        public string? Language { get; set; } = default!;
        public string? Country { get; set; } = default!;
        public string? ContentRating { get; set; } = default!; // PG, PG-13, R, etc.
        public bool IsFeatured { get; set; } = false;
        public bool IsTrending { get; set; } = false;
        public DateTime? AddedDate { get; set; } = default!;
        
        // Navigation properties
        public List<Director> Directors { get; set; } = [];
        public List<Actor> Actors { get; set; } = [];
        public List<Rating> Ratings { get; set; } = [];
        public List<Comment> Comments { get; set; } = [];
        public List<MovieGenre> MovieGenres { get; set; } = [];
    }

    public class Director
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = default!;
        public string? Biography { get; set; } = default!;
        public DateTime? BirthDate { get; set; } = default!;
        public string? ProfileImageUrl { get; set; } = default!;
        public string? Nationality { get; set; } = default!;
        
        public List<Movie> Movies { get; set; } = [];
    }

    public class Actor
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = default!;
        public string? Biography { get; set; } = default!;
        public DateTime? BirthDate { get; set; } = default!;
        public string? ProfileImageUrl { get; set; } = default!;
        public string? Nationality { get; set; } = default!;
        
        public List<MovieActor> MovieActors { get; set; } = [];
    }

    public class MovieActor
    {
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; } = default!;
        
        public Guid ActorId { get; set; }
        public Actor? Actor { get; set; } = default!;
        
        public string? Character { get; set; } = default!;
        public int Order { get; set; } // Billing order
    }

    public class Rating
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; } = default!;
        
        public string? UserId { get; set; } = default!; // User identifier
        public string? UserName { get; set; } = default!;
        public int RatingValue { get; set; } // 1-5 stars
        public DateTime? CreatedDate { get; set; } = default!;
    }

    public class Comment
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; } = default!;
        
        public string? UserId { get; set; } = default!; // User identifier
        public string? UserName { get; set; } = default!;
        public string? Text { get; set; } = default!;
        public DateTime? CreatedDate { get; set; } = default!;
        public DateTime? UpdatedDate { get; set; } = default!;
        
        // For replies to comments
        public Guid? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; } = default!;
        public List<Comment> Replies { get; set; } = [];
    }

    public class Genre
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = default!;
        public string? Description { get; set; } = default!;
        
        public List<MovieGenre> MovieGenres { get; set; } = [];
    }

    public class MovieGenre
    {
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; } = default!;
        
        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; } = default!;
    }

    public class UserPreference
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; } = default!;
        public string? UserName { get; set; } = default!;
        public List<string> PreferredGenres { get; set; } = [];
        public List<Guid> WatchedMovies { get; set; } = [];
        public List<Guid> FavoriteMovies { get; set; } = [];
        public DateTime? LastUpdated { get; set; } = default!;
    }
}
