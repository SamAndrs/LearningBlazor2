using MovieStoreGUI.Models;

namespace MovieStoreGUI.Clients
{
    public class GenresClient(HttpClient httpClient)
    {
        // GET/ genres
        // retrieves all genres in database, and puts them in array or returns empty array if no movies.
        public async Task<Genre[]> GetGenresAsync() =>
            await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];
    }
}
