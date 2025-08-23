using Library_Management.Models;
using Library_Management_Domain.Entities;

public class MovieService
{
    private readonly ICollection<Movie> _movies = new List<Movie>();
    private readonly ICollection<Director> _directors = new List<Director>();
    private readonly ICollection<Actor> _actors = new List<Actor>();
    private readonly ICollection<Rating> _ratings = new List<Rating>();
    private readonly ICollection<Comment> _comments = new List<Comment>();
    private readonly ICollection<UserPreference> _userPreferences = new List<UserPreference>();

    private MovieService()
    {
        SeedData();
    }

    private void SeedData()
    {
        // Create Directors
        var christopherNolan = new Director
        {
            Id = Guid.NewGuid(),
            Name = "Christopher Nolan",
            Biography = "British-American film director, producer, and screenwriter.",
            BirthDate = new DateTime(1970, 7, 30),
            ProfileImageUrl = "https://image.tmdb.org/t/p/w500/xuAIuYSmsUzKlUMBFGVZaWsY3DZ.jpg",
            Nationality = "British-American"
        };

        var tarantinoId = Guid.NewGuid();
        var tarantino = new Director
        {
            Id = tarantinoId,
            Name = "Quentin Tarantino",
            Biography = "American film director, writer, producer, and actor.",
            BirthDate = new DateTime(1963, 3, 27),
            ProfileImageUrl = "https://image.tmdb.org/t/p/w500/1gjcpAa99FAOWGnrUvHEXXsRs7o.jpg",
            Nationality = "American"
        };

        // Create Actors
        var leonardoDiCaprio = new Actor
        {
            Id = Guid.NewGuid(),
            Name = "Leonardo DiCaprio",
            Biography = "American actor and producer.",
            BirthDate = new DateTime(1974, 11, 11),
            ProfileImageUrl = "https://image.tmdb.org/t/p/w500/wo2hJpn04vbtmh0B9utCFdsQhxM.jpg",
            Nationality = "American"
        };

        var marionCotillard = new Actor
        {
            Id = Guid.NewGuid(),
            Name = "Marion Cotillard",
            Biography = "French actress and singer.",
            BirthDate = new DateTime(1975, 9, 30),
            ProfileImageUrl = "https://image.tmdb.org/t/p/w500/rK7qyLaL5KiayMDrp3FKYlntzZ5.jpg",
            Nationality = "French"
        };

        var johnTravolta = new Actor
        {
            Id = Guid.NewGuid(),
            Name = "John Travolta",
            Biography = "American actor, producer, dancer, and singer.",
            BirthDate = new DateTime(1954, 2, 18),
            ProfileImageUrl = "https://image.tmdb.org/t/p/w500/9GVufE87MMIrSn0CbJFLudkALdL.jpg",
            Nationality = "American"
        };

        var samuelLJackson = new Actor
        {
            Id = Guid.NewGuid(),
            Name = "Samuel L. Jackson",
            Biography = "American actor and producer.",
            BirthDate = new DateTime(1948, 12, 21),
            ProfileImageUrl = "https://image.tmdb.org/t/p/w500/AiAYAqwpM5xmiFrAIeQvUXDCVvo.jpg",
            Nationality = "American"
        };

        // Create Movies
        var inceptionId = Guid.NewGuid();
        var inception = new Movie
        {
            Id = inceptionId,
            Title = "Inception",
            Description = "A thief who enters people's dreams to steal secrets from their subconscious gets a chance to have his criminal record erased.",
            Genre = "Sci-Fi",
            ReleaseDate = new DateTime(2010, 7, 16),
            Runtime = 148,
            TrailerUrl = "https://www.youtube.com/watch?v=YoHD9XEInc0",
            PosterUrl = "https://image.tmdb.org/t/p/w500/9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
            BackdropUrl = "https://image.tmdb.org/t/p/w1280/s3TBrRGB1iav7gFOCNx3H31MoES.jpg",
            Language = "English",
            Country = "USA",
            ContentRating = "PG-13",
            IsFeatured = true,
            IsTrending = true,
            AddedDate = DateTime.Now.AddDays(-30)
        };

        var pulpFictionId = Guid.NewGuid();
        var pulpFiction = new Movie
        {
            Id = pulpFictionId,
            Title = "Pulp Fiction",
            Description = "The lives of two mob hitmen, a boxer, a gangster and his wife intertwine in four tales of violence and redemption.",
            Genre = "Crime",
            ReleaseDate = new DateTime(1994, 10, 14),
            Runtime = 154,
            TrailerUrl = "https://www.youtube.com/watch?v=s7EdQ4FqbhY",
            PosterUrl = "https://image.tmdb.org/t/p/w500/d5iIlFn5s0ImszYzBPb8JPIfbXD.jpg",
            BackdropUrl = "https://image.tmdb.org/t/p/w1280/4cDFJr4HnXN5AdPw4AKrmLlMWdO.jpg",
            Language = "English",
            Country = "USA",
            ContentRating = "R",
            IsFeatured = false,
            IsTrending = true,
            AddedDate = DateTime.Now.AddDays(-60)
        };

        // Additional popular movies
        var movies = new[]
        {
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "The Dark Knight",
                Description = "When the menace known as the Joker wreaks havoc on Gotham City, Batman must accept one of the greatest psychological tests.",
                Genre = "Action",
                ReleaseDate = new DateTime(2008, 7, 18),
                Runtime = 152,
                PosterUrl = "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg",
                BackdropUrl = "https://image.tmdb.org/t/p/w1280/hkufdvPvv3hKaJk9wd5XoBtDJ1w.jpg",
                Language = "English",
                Country = "USA",
                ContentRating = "PG-13",
                IsFeatured = true,
                AddedDate = DateTime.Now.AddDays(-45)
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "The Godfather",
                Description = "An organized crime dynasty's aging patriarch transfers control to his reluctant son.",
                Genre = "Drama",
                ReleaseDate = new DateTime(1972, 3, 24),
                Runtime = 175,
                PosterUrl = "https://image.tmdb.org/t/p/w500/3bhkrj58Vtu7enYsRolD1fZdja1.jpg",
                BackdropUrl = "https://image.tmdb.org/t/p/w1280/tmU7GeKVybMWFButWEGl2M4GeiP.jpg",
                Language = "English",
                Country = "USA",
                ContentRating = "R",
                IsTrending = true,
                AddedDate = DateTime.Now.AddDays(-90)
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Avatar",
                Description = "A paraplegic Marine dispatched to the moon Pandora joins a mission to mine unobtainium.",
                Genre = "Sci-Fi",
                ReleaseDate = new DateTime(2009, 12, 18),
                Runtime = 162,
                PosterUrl = "https://image.tmdb.org/t/p/w500/6EiRUJpuoeQPghrs8UVelaNT6Dq.jpg",
                BackdropUrl = "https://image.tmdb.org/t/p/w1280/Yc9q6QuWrMp9nuDm5R8ExNqbEWU.jpg",
                Language = "English",
                Country = "USA",
                ContentRating = "PG-13",
                IsFeatured = false,
                AddedDate = DateTime.Now.AddDays(-75)
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Titanic",
                Description = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious Titanic.",
                Genre = "Romance",
                ReleaseDate = new DateTime(1997, 12, 19),
                Runtime = 194,
                PosterUrl = "https://image.tmdb.org/t/p/w500/9xjZS2rlVxm8SFx8kPC3aIGCOYQ.jpg",
                BackdropUrl = "https://image.tmdb.org/t/p/w1280/kHXEpyfl6zqn8a6YuozOUJYyUI6.jpg",
                Language = "English",
                Country = "USA",
                ContentRating = "PG-13",
                IsTrending = false,
                AddedDate = DateTime.Now.AddDays(-120)
            }
        };

        // Add to collections
        _directors.Add(christopherNolan);
        _directors.Add(tarantino);
        _actors.Add(leonardoDiCaprio);
        _actors.Add(marionCotillard);
        _actors.Add(johnTravolta);
        _actors.Add(samuelLJackson);

        inception.Directors.Add(christopherNolan);
        pulpFiction.Directors.Add(tarantino);

        _movies.Add(inception);
        _movies.Add(pulpFiction);
        foreach (var movie in movies)
        {
            _movies.Add(movie);
        }

        // Add sample ratings and comments
        var sampleRatings = new[]
        {
            new Rating { Id = Guid.NewGuid(), MovieId = inceptionId, UserId = "user1", UserName = "MovieFan23", RatingValue = 5, CreatedDate = DateTime.Now.AddDays(-10) },
            new Rating { Id = Guid.NewGuid(), MovieId = inceptionId, UserId = "user2", UserName = "CinemaLover", RatingValue = 4, CreatedDate = DateTime.Now.AddDays(-8) },
            new Rating { Id = Guid.NewGuid(), MovieId = pulpFictionId, UserId = "user1", UserName = "MovieFan23", RatingValue = 5, CreatedDate = DateTime.Now.AddDays(-15) },
            new Rating { Id = Guid.NewGuid(), MovieId = pulpFictionId, UserId = "user3", UserName = "FilmCritic", RatingValue = 4, CreatedDate = DateTime.Now.AddDays(-12) }
        };

        var sampleComments = new[]
        {
            new Comment { Id = Guid.NewGuid(), MovieId = inceptionId, UserId = "user1", UserName = "MovieFan23", Text = "Mind-blowing concept and execution!", CreatedDate = DateTime.Now.AddDays(-9) },
            new Comment { Id = Guid.NewGuid(), MovieId = inceptionId, UserId = "user2", UserName = "CinemaLover", Text = "Nolan at his best. Complex but rewarding.", CreatedDate = DateTime.Now.AddDays(-7) },
            new Comment { Id = Guid.NewGuid(), MovieId = pulpFictionId, UserId = "user3", UserName = "FilmCritic", Text = "Tarantino's masterpiece. Iconic dialogue and characters.", CreatedDate = DateTime.Now.AddDays(-11) }
        };

        foreach (var rating in sampleRatings)
        {
            _ratings.Add(rating);
        }

        foreach (var comment in sampleComments)
        {
            _comments.Add(comment);
        }
    }

    // Movie CRUD Operations
    public void AddMovie(AddMovieViewModel movie)
    {
        ArgumentNullException.ThrowIfNull(movie, nameof(movie));

        var newMovie = new Movie
        {
            Id = Guid.NewGuid(),
            Title = movie.Title,
            Description = movie.Description,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate,
            Runtime = movie.Runtime,
            TrailerUrl = movie.TrailerUrl,
            PosterUrl = movie.PosterUrl,
            BackdropUrl = movie.BackdropUrl,
            Language = movie.Language,
            Country = movie.Country,
            ContentRating = movie.ContentRating,
            IsFeatured = movie.IsFeatured,
            IsTrending = movie.IsTrending,
            AddedDate = DateTime.Now
        };

        // Handle Director
        var existingDirector = _directors.FirstOrDefault(d => d.Name == movie.DirectorName);
        if (existingDirector == null)
        {
            var newDirector = new Director
            {
                Id = Guid.NewGuid(),
                Name = movie.DirectorName,
                Biography = movie.DirectorBiography,
                ProfileImageUrl = movie.DirectorProfileImageUrl,
                Nationality = movie.DirectorNationality
            };
            _directors.Add(newDirector);
            newMovie.Directors.Add(newDirector);
        }
        else
        {
            newMovie.Directors.Add(existingDirector);
        }

        _movies.Add(newMovie);
    }

    public IEnumerable<MovieListViewModel> GetMovies()
    {
        return _movies.Select(m => new MovieListViewModel
        {
            MovieId = m.Id,
            Title = m.Title,
            Description = m.Description,
            Genre = m.Genre,
            ReleaseDate = m.ReleaseDate,
            Runtime = m.Runtime,
            TrailerUrl = m.TrailerUrl,
            PosterUrl = m.PosterUrl,
            BackdropUrl = m.BackdropUrl,
            Language = m.Language,
            Country = m.Country,
            ContentRating = m.ContentRating,
            IsFeatured = m.IsFeatured,
            IsTrending = m.IsTrending,
            DirectorName = m.Directors.FirstOrDefault()?.Name,
            DirectorProfileImageUrl = m.Directors.FirstOrDefault()?.ProfileImageUrl,
            AverageRating = CalculateAverageRating(m.Id),
            TotalRatings = _ratings.Count(r => r.MovieId == m.Id),
            TotalComments = _comments.Count(c => c.MovieId == m.Id)
        });
    }

    public MovieDetailsViewModel? GetMovieById(Guid id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return null;

        var movieRatings = _ratings.Where(r => r.MovieId == id).ToList();
        var movieComments = _comments.Where(c => c.MovieId == id && c.ParentCommentId == null).ToList();

        return new MovieDetailsViewModel
        {
            MovieId = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate,
            Runtime = movie.Runtime,
            TrailerUrl = movie.TrailerUrl,
            PosterUrl = movie.PosterUrl,
            BackdropUrl = movie.BackdropUrl,
            Language = movie.Language,
            Country = movie.Country,
            ContentRating = movie.ContentRating,
            IsFeatured = movie.IsFeatured,
            IsTrending = movie.IsTrending,
            Directors = movie.Directors.Select(d => new DirectorViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Biography = d.Biography,
                ProfileImageUrl = d.ProfileImageUrl,
                Nationality = d.Nationality
            }).ToList(),
            Ratings = movieRatings.Select(r => new RatingViewModel
            {
                Id = r.Id,
                UserName = r.UserName,
                RatingValue = r.RatingValue,
                CreatedDate = r.CreatedDate
            }).ToList(),
            Comments = movieComments.Select(c => new CommentViewModel
            {
                Id = c.Id,
                UserName = c.UserName,
                Text = c.Text,
                CreatedDate = c.CreatedDate,
                UpdatedDate = c.UpdatedDate,
                Replies = GetCommentReplies(c.Id)
            }).ToList(),
            AverageRating = CalculateAverageRating(id),
            TotalRatings = movieRatings.Count,
            SuggestedMovies = GetSuggestedMovies(movie.Genre, id).Take(6).ToList()
        };
    }

    public EditMovieViewModel? GetMovieForEdit(Guid id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return null;

        var director = movie.Directors.FirstOrDefault();

        return new EditMovieViewModel
        {
            MovieId = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate,
            Runtime = movie.Runtime,
            TrailerUrl = movie.TrailerUrl,
            PosterUrl = movie.PosterUrl,
            BackdropUrl = movie.BackdropUrl,
            Language = movie.Language,
            Country = movie.Country,
            ContentRating = movie.ContentRating,
            IsFeatured = movie.IsFeatured,
            IsTrending = movie.IsTrending,
            DirectorId = director?.Id,
            DirectorName = director?.Name,
            DirectorBiography = director?.Biography,
            DirectorProfileImageUrl = director?.ProfileImageUrl,
            DirectorNationality = director?.Nationality
        };
    }

    public void UpdateMovie(EditMovieViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm, nameof(vm));

        var movie = _movies.FirstOrDefault(m => m.Id == vm.MovieId);
        if (movie == null) throw new KeyNotFoundException("Movie not found");

        movie.Title = vm.Title;
        movie.Description = vm.Description;
        movie.Genre = vm.Genre;
        movie.ReleaseDate = vm.ReleaseDate;
        movie.Runtime = vm.Runtime;
        movie.TrailerUrl = vm.TrailerUrl;
        movie.PosterUrl = vm.PosterUrl;
        movie.BackdropUrl = vm.BackdropUrl;
        movie.Language = vm.Language;
        movie.Country = vm.Country;
        movie.ContentRating = vm.ContentRating;
        movie.IsFeatured = vm.IsFeatured;
        movie.IsTrending = vm.IsTrending;

        // Update Director
        movie.Directors.Clear();
        var director = _directors.FirstOrDefault(d => d.Id == vm.DirectorId);
        if (director == null)
        {
            director = new Director
            {
                Id = Guid.NewGuid(),
                Name = vm.DirectorName,
                Biography = vm.DirectorBiography,
                ProfileImageUrl = vm.DirectorProfileImageUrl,
                Nationality = vm.DirectorNationality
            };
            _directors.Add(director);
        }
        else
        {
            director.Name = vm.DirectorName;
            director.Biography = vm.DirectorBiography;
            director.ProfileImageUrl = vm.DirectorProfileImageUrl;
            director.Nationality = vm.DirectorNationality;
        }
        movie.Directors.Add(director);
    }

    public void DeleteMovie(Guid id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) throw new KeyNotFoundException("Movie not found");

        _movies.Remove(movie);
        
        // Remove associated ratings and comments
        var ratingsToRemove = _ratings.Where(r => r.MovieId == id).ToList();
        foreach (var rating in ratingsToRemove)
        {
            _ratings.Remove(rating);
        }

        var commentsToRemove = _comments.Where(c => c.MovieId == id).ToList();
        foreach (var comment in commentsToRemove)
        {
            _comments.Remove(comment);
        }
    }

    // Rating System
    public void AddRating(RateMovieViewModel ratingViewModel)
    {
        ArgumentNullException.ThrowIfNull(ratingViewModel, nameof(ratingViewModel));

        // Remove existing rating by the same user
        var existingRating = _ratings.FirstOrDefault(r => r.MovieId == ratingViewModel.MovieId && r.UserName == ratingViewModel.UserName);
        if (existingRating != null)
        {
            _ratings.Remove(existingRating);
        }

        var rating = new Rating
        {
            Id = Guid.NewGuid(),
            MovieId = ratingViewModel.MovieId,
            UserId = ratingViewModel.UserName?.Replace(" ", "").ToLower(),
            UserName = ratingViewModel.UserName,
            RatingValue = ratingViewModel.RatingValue,
            CreatedDate = DateTime.Now
        };

        _ratings.Add(rating);
    }

    public double CalculateAverageRating(Guid movieId)
    {
        var movieRatings = _ratings.Where(r => r.MovieId == movieId).ToList();
        return movieRatings.Any() ? Math.Round(movieRatings.Average(r => r.RatingValue), 1) : 0.0;
    }

    // Comment System
    public void AddComment(AddCommentViewModel commentViewModel)
    {
        ArgumentNullException.ThrowIfNull(commentViewModel, nameof(commentViewModel));

        var comment = new Comment
        {
            Id = Guid.NewGuid(),
            MovieId = commentViewModel.MovieId,
            UserId = commentViewModel.UserName?.Replace(" ", "").ToLower(),
            UserName = commentViewModel.UserName,
            Text = commentViewModel.Text,
            CreatedDate = DateTime.Now,
            ParentCommentId = commentViewModel.ParentCommentId
        };

        _comments.Add(comment);
    }

    private List<CommentViewModel> GetCommentReplies(Guid commentId)
    {
        return _comments
            .Where(c => c.ParentCommentId == commentId)
            .Select(c => new CommentViewModel
            {
                Id = c.Id,
                UserName = c.UserName,
                Text = c.Text,
                CreatedDate = c.CreatedDate,
                UpdatedDate = c.UpdatedDate
            }).ToList();
    }

    // Recommendation System
    public List<MovieListViewModel> GetSuggestedMovies(string? genre, Guid? excludeMovieId = null)
    {
        var movies = GetMovies().AsQueryable();
        
        if (excludeMovieId.HasValue)
        {
            movies = movies.Where(m => m.MovieId != excludeMovieId.Value);
        }

        // Prioritize same genre movies
        var sameGenreMovies = movies.Where(m => m.Genre == genre).OrderByDescending(m => m.AverageRating);
        var otherMovies = movies.Where(m => m.Genre != genre).OrderByDescending(m => m.IsTrending).ThenByDescending(m => m.AverageRating);

        return sameGenreMovies.Concat(otherMovies).Take(10).ToList();
    }

    public List<MovieListViewModel> GetFeaturedMovies()
    {
        return GetMovies().Where(m => m.IsFeatured).OrderByDescending(m => m.AverageRating).ToList();
    }

    public List<MovieListViewModel> GetTrendingMovies()
    {
        return GetMovies().Where(m => m.IsTrending).OrderByDescending(m => m.AverageRating).ToList();
    }

    public List<MovieListViewModel> GetTopRatedMovies()
    {
        return GetMovies().OrderByDescending(m => m.AverageRating).ThenByDescending(m => m.TotalRatings).Take(20).ToList();
    }

    public List<MovieListViewModel> GetRecentlyAddedMovies()
    {
        return GetMovies().OrderByDescending(m => m.ReleaseDate).Take(20).ToList();
    }

    public List<MovieListViewModel> SearchMovies(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return GetMovies().ToList();

        searchTerm = searchTerm.ToLower();
        return GetMovies()
            .Where(m => (m.Title?.ToLower().Contains(searchTerm) ?? false) || 
                       (m.Description?.ToLower().Contains(searchTerm) ?? false) ||
                       (m.Genre?.ToLower().Contains(searchTerm) ?? false) ||
                       (m.DirectorName?.ToLower().Contains(searchTerm) ?? false))
            .ToList();
    }

    public List<MovieListViewModel> GetMoviesByGenre(string genre)
    {
        return GetMovies().Where(m => m.Genre?.Equals(genre, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
    }

    // Singleton pattern
    private static MovieService? _instance;
    public static MovieService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MovieService();
            }
            return _instance;
        }
    }
}
