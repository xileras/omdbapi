export interface MovieSearchResult {
    search: MovieDetails[]
    totalResults: string
    response: string
}

export interface MovieDetails {
    title: string
    year: string
    imdbID: string
    type: string
    poster: string
}
