using OMDB.API.Data;
using System.Text;

namespace OMDB.API.Helpers
{
    internal class ParameterParser
    {
        /// <summary>
        /// Builds the necessary querystring to append to the <see cref="http://www.omdbapi.com/"/> URL for a Lookup.
        /// </summary>
        /// <param name="parameters">The <see cref="MovieLookupParameters"/> parameters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string BuildUrlParametersForLookup(MovieLookupParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.IMDbID) && string.IsNullOrEmpty(parameters.Title))
            {
                throw new ArgumentException("Must specify either a valid IMDb ID or movie title");
            }

            var builder = new StringBuilder("&");

            if (!string.IsNullOrEmpty(parameters.IMDbID))
            {
                builder.Append($"i={parameters.IMDbID}&");
            }

            if (!string.IsNullOrEmpty(parameters.Title))
            {
                builder.Append($"t={parameters.Title}&");
            }

            var mediaTypeString = parameters.Type.ToString().ToLower();

            builder.Append($"type={mediaTypeString}&");

            if (parameters.Year.HasValue)
            {
                builder.Append($"y={parameters.Year.Value}&");
            }

            builder.Append($"plot={(parameters.IsShortPlot ? "short" : "full")}");

            return builder.ToString();
        }

        /// <summary>
        /// Builds the necessary querystring to append to the <see cref="http://www.omdbapi.com/"/> URL for a Search.
        /// </summary>
        /// <param name="parameters">The <see cref="MovieSearchParameters"/> parameters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string BuildUrlParametersForSearch(MovieSearchParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.Title))
            {
                throw new ArgumentException("Must specify a valid movie title");
            }

            if (parameters.Page == 0) parameters.Page= 1;

            if (!(parameters.Page >= 1 && parameters.Page <= 100))
            {
                throw new ArgumentOutOfRangeException("Page value is outside the valid range of 1 to 100");
            }

            var builder = new StringBuilder("&");

            if (!string.IsNullOrEmpty(parameters.Title))
            {
                builder.Append($"s={parameters.Title}&");
            }

            var mediaTypeString = parameters.Type.ToString().ToLower();

            builder.Append($"type={mediaTypeString}&");

            builder.Append($"page={parameters.Page}");

            return builder.ToString();
        }
    }
}
