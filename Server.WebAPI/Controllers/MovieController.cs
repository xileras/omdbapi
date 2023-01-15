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

        [HttpGet]
        public async Task<MovieLookupResult> Get()
        {
            return await _omdbMovieWrapper.GetMovieByTitleOrID(new MovieLookupParameters { IMDbID = "tt1285016" });
        }

        [HttpGet("GetMoviesByName/{name}")]
        public async Task<MovieSearchResult> GetMoviesByName(string name)
        {
            return await _omdbMovieWrapper.GetMoviesBySearch(new MovieSearchParameters { Title = name });
        }
    }
}
