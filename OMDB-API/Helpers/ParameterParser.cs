using OMDB.API.Data;
using System.Text;

namespace OMDB.API.Helpers
{
    internal class ParameterParser
    {
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

        public static string BuildUrlParametersForSearch(MovieSearchParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.Title))
            {
                throw new ArgumentException("Must specify either a valid movie title");
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
