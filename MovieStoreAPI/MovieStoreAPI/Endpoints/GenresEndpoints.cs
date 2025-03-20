using Microsoft.EntityFrameworkCore;
using MovieStoreAPI.Data;

namespace MovieStoreAPI.Endpoints
{
    public static class GenresEndpoints
    {
        public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("genres").WithParameterValidation();

            //GET /genres
            group.MapGet("/", async (MovieContext movieContext) => 
                                                await movieContext.Genres.ToListAsync());

            return group;
        }
    }
}
