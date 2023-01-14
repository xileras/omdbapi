using Microsoft.AspNetCore.Mvc;
using OMDB.API;
using OMDB.API.Data;

namespace Server.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly OmdbMovieWrapper _omdbMovieWrapper;

        public MovieController(OmdbMovieWrapper omdbMovieWrapper)
        {
            _omdbMovieWrapper = omdbMovieWrapper; // Probably should be DI.
        }

        [HttpGet]
        public async Task<MovieLookupResult> Get()
        {
            var movie = await _omdbMovieWrapper.GetMovieByTitleOrID(new MovieLookupParameters { IMDbID = "tt1285016" });

            return movie;
        }

        [HttpGet("GetMoviesByName/{name}")]
        public async Task<MovieSearchResult> GetMoviesByName(string name)
        {
            // GetMoviesByName
            var movies = await _omdbMovieWrapper.GetMoviesBySearch(new MovieSearchParameters { Title = name });

            return movies;
        }

    }
}
