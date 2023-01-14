using OMDB.API.Data.Enums;

namespace OMDB.API.Data
{
    public class MovieSearchParameters
    {
        public string Title { get; set; }

        public MediaType Type { get; set; }

        public int Page { get; set; }
    }
}
