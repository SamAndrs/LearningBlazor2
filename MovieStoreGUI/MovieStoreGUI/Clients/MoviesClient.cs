using MovieStoreGUI.Models;

namespace MovieStoreGUI.Clients
{
    public class MoviesClient(HttpClient httpClient)
    {
        // GET/ movies
        // retrieves all movies in database, and puts them in array or returns empty array if no movies.
        public async Task<Movie[]> GetMoviesAsync() =>
            await httpClient.GetFromJsonAsync<Movie[]>("movies") ?? [];

        // GET/ movies/id
        public async Task<Movie> GetMovieAsync(int id) =>
            await httpClient.GetFromJsonAsync<Movie>($"movies/{id}") 
                                        ?? throw new Exception("movie not found");

        // POST/ movies
        public async Task AddMovieAsync(Movie movie) => await httpClient.PostAsJsonAsync("movies", movie);


        // PUT/ movies/id
        public async Task UpdateMovieAsync(Movie updatedMovie) =>
            await httpClient.PutAsJsonAsync($"movies/{updatedMovie.Id}", updatedMovie);

        // DELETE /movies/id
        public async Task DeleteMovieAsync(int id) => await httpClient.DeleteAsync($"movies/{id}");
        
    }
}
