using Common.Http;
using Microsoft.Extensions.Configuration;
using OMDB.API.Data;
using OMDB.API.Helpers;

namespace OMDB.API
{
    /// <summary>
    /// Wrapper class that encapsulates all calls to the <see cref="http://www.omdbapi.com/"/> API.
    /// </summary>
    public sealed class OmdbMovieWrapper
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClientService _httpClientService;        

        public OmdbMovieWrapper(IConfiguration configuration)
        {
            _configuration= configuration;
            _httpClientService = new HttpClientService($"{_configuration["OMDBAPI:url"]}/?apikey={_configuration["OMDBAPI:apiKey"]}");
        }

        /// <summary>
        /// Gets the details of a movie, series or episode by searching for a valid IMDb ID or the closest matching title.
        /// </summary>
        /// <param name="parameters">Lookup parameters used to help locate the specified movie, series or episode. See <see cref="http://www.omdbapi.com/"/> for more details.</param>
        /// <returns>A single movie, series or episode, with all relevant details.</returns>
        /// <exception cref="ArgumentNullException">Thrown when parameters are missing.</exception>
        /// <exception cref="ArgumentException">Thrown when both IMDb ID and title has not been specified.</exception>
        public async Task<MovieLookupResult> GetMovieByTitleOrID(MovieLookupParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var urlParameters = ParameterParser.BuildUrlParametersForLookup(parameters);

            var movie = await _httpClientService.Get<MovieLookupResult>(urlParameters);

            return movie;
        }

        /// <summary>
        /// Searches for all matching movies, series or episodes, based on the specified parameters, to a maximum of 10 per page.
        /// </summary>
        /// <param name="parameters">Lookup parameters used to help locate the specified movie, series or episode. See <see cref="http://www.omdbapi.com/"/> for more details.</param>
        /// <returns>All matching movies, series or episodes, with minimum details.</returns>
        /// <exception cref="ArgumentNullException">Thrown when parameters are missing.</exception>
        /// <exception cref="ArgumentException">Thrown when a title has not been specified, or when the specified page number is out of range (1 to 100).</exception>
        public async Task<MovieSearchResult> GetMoviesBySearch(MovieSearchParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var urlParameters = ParameterParser.BuildUrlParametersForSearch(parameters);

            var movies = await _httpClientService.Get<MovieSearchResult>(urlParameters);

            return movies;
        }
    }
}