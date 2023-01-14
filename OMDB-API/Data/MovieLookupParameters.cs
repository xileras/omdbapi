using OMDB.API.Data.Enums;

namespace OMDB.API.Data
{
    public class MovieLookupParameters
    {
        public string IMDbID { get; set; }

        public string Title { get; set; }

        public MediaType Type { get; set; }

        public int? Year { get; set; }

        public bool IsShortPlot { get; set; }
    }
}
