namespace OMDB.API.Data
{
    public class MovieSearchResult
    {
        public List<MovieDetails> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}
