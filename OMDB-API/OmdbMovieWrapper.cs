using Common.Http;
using OMDB.API.Data;
using OMDB.API.Helpers;

namespace OMDB.API
{
    public class OmdbMovieWrapper
    {
        private readonly HttpClientService httpClientService;

        public OmdbMovieWrapper()
        {
            httpClientService = new HttpClientService("http://www.omdbapi.com/?apikey=4534fb7b");
        }

        public async Task<MovieLookupResult> GetMovieByTitleOrID(MovieLookupParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var urlParameters = ParameterParser.BuildUrlParametersForLookup(parameters);

            var movie = await httpClientService.Get<MovieLookupResult>(urlParameters);

            return movie;
        }

        public async Task<MovieSearchResult> GetMoviesBySearch(MovieSearchParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var urlParameters = ParameterParser.BuildUrlParametersForSearch(parameters);

            var movies = await httpClientService.Get<MovieSearchResult>(urlParameters);

            return movies;
        }
    }
}