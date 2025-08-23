using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index(string? searchTerm, string? genre)
        {
            IEnumerable<MovieListViewModel> movies;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                movies = MovieService.Instance.SearchMovies(searchTerm);
            }
            else if (!string.IsNullOrEmpty(genre))
            {
                movies = MovieService.Instance.GetMoviesByGenre(genre);
            }
            else
            {
                movies = MovieService.Instance.GetMovies();
            }

            ViewBag.SearchTerm = searchTerm;
            ViewBag.SelectedGenre = genre;
            ViewBag.FeaturedMovies = MovieService.Instance.GetFeaturedMovies();
            ViewBag.TrendingMovies = MovieService.Instance.GetTrendingMovies();
            ViewBag.TopRatedMovies = MovieService.Instance.GetTopRatedMovies();
            
            return View(movies);
        }

        public IActionResult Featured()
        {
            var featuredMovies = MovieService.Instance.GetFeaturedMovies();
            return View(featuredMovies);
        }

        public IActionResult Trending()
        {
            var trendingMovies = MovieService.Instance.GetTrendingMovies();
            return View(trendingMovies);
        }

        public IActionResult TopRated()
        {
            var topRatedMovies = MovieService.Instance.GetTopRatedMovies();
            return View(topRatedMovies);
        }

        public IActionResult AddModal()
        {
            return PartialView("_AddMoviePartial");
        }

        [HttpPost]
        public IActionResult Add(AddMovieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MovieService.Instance.AddMovie(vm);
            return Ok();
        }

        public IActionResult EditModal(Guid id)
        {
            var editMovieViewModel = MovieService.Instance.GetMovieForEdit(id);
            if (editMovieViewModel == null) return NotFound();

            return PartialView("_EditMoviePartial", editMovieViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditMovieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MovieService.Instance.UpdateMovie(vm);
            return Ok();
        }

        public IActionResult DeleteModal(Guid id)
        {
            return PartialView("_DeleteMoviePartial", new { id });
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                MovieService.Instance.DeleteMovie(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        public IActionResult Details(Guid id)
        {
            var movie = MovieService.Instance.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public IActionResult Rate(RateMovieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MovieService.Instance.AddRating(vm);
            
            // Return the updated average rating
            var averageRating = MovieService.Instance.CalculateAverageRating(vm.MovieId);
            return Json(new { success = true, averageRating });
        }

        [HttpPost]
        public IActionResult AddComment(AddCommentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MovieService.Instance.AddComment(vm);
            
            // Return success response
            return Json(new { success = true, message = "Comment added successfully!" });
        }

        [HttpGet]
        public IActionResult GetSuggestions(Guid movieId)
        {
            var movie = MovieService.Instance.GetMovieById(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            var suggestions = MovieService.Instance.GetSuggestedMovies(movie.Genre, movieId);
            return PartialView("_MovieSuggestions", suggestions);
        }

        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Json(new List<MovieListViewModel>());
            }

            var movies = MovieService.Instance.SearchMovies(searchTerm);
            return Json(movies.Take(10).Select(m => new {
                id = m.MovieId,
                title = m.Title,
                poster = m.PosterUrl,
                genre = m.Genre,
                rating = m.AverageRating,
                year = m.ReleaseDate?.Year
            }));
        }

        [HttpGet]
        public IActionResult GetByGenre(string genre)
        {
            var movies = MovieService.Instance.GetMoviesByGenre(genre);
            return PartialView("_MovieGrid", movies);
        }
    }
}
