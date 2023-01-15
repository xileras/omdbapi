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
            _omdbMovieWrapper = omdbMovieWrapper;
        }

        [HttpGet("{imdbId}")]
        public async Task<MovieLookupResult> Get(string imdbId)
        {
            return await _omdbMovieWrapper.GetMovieByTitleOrID(new MovieLookupParameters { IMDbID = imdbId });
        }

        [HttpGet("GetMoviesByName/{name}")]
        public async Task<MovieSearchResult> GetMoviesByName(string name)
        {
            return await _omdbMovieWrapper.GetMoviesBySearch(new MovieSearchParameters { Title = name });
        }

        [HttpGet("GetMoviePoster")]
        public async Task GetMoviePoster()
        {
            throw new NotImplementedException("We must become patrons in order to access the Poster API");
        }
    }
}
