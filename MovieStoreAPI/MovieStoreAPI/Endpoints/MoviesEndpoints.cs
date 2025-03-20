using Microsoft.EntityFrameworkCore;
using MovieStoreAPI.Data;
using MovieStoreAPI.Entities;
using System.Runtime.CompilerServices;

namespace MovieStoreAPI.Endpoints
{
    public static class MoviesEndpoints
    {
        // Extension Method (method added to a class)
        public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("movies").WithParameterValidation();


            // GET /movies
            group.MapGet("/", async (MovieContext movieContext) =>
                                        await movieContext.Movies
                                        .Include("Genre")
                                        .ToListAsync());


            //GET /movies/id
            group.MapGet("/{id}", async (MovieContext movieContext, int id) =>
            {
                Movie? movie = await movieContext.Movies
                                        .Include("Genre")
                                        .FirstOrDefaultAsync(m => m.Id == id);

                return movie is null ? Results.NotFound() : Results.Ok(movie);
            });


            //POST /movies
            group.MapPost("/", async (Movie newMovie, MovieContext movieContext) =>
            {
                newMovie.Genre = await movieContext.Genres.FirstOrDefaultAsync(g => g.Id == newMovie.GenreId);
                await movieContext.Movies.AddAsync(newMovie);
                await movieContext.SaveChangesAsync();
                return Results.Created($"/movies/{newMovie.Id}", newMovie);
            });


            //PUT /movies/id
            group.MapPut("/{id}", async (int id, Movie updatedMovie, MovieContext movieContext) =>
            {
                Movie? movie = await movieContext.Movies.FindAsync(id);

                if(movie is null)
                {
                    return Results.NotFound();
                }

                if(updatedMovie.Name is not null) { movie.Name = updatedMovie.Name; }
                if(updatedMovie.GenreId != 0) { movie.GenreId = updatedMovie.GenreId;
                                movie.Genre = movieContext.Genres.Find(updatedMovie.GenreId); }

                if(updatedMovie.Price <= 0) { movie.Price = updatedMovie.Price; }
                if(updatedMovie.ReleaseDate != default) { movie.ReleaseDate = updatedMovie.ReleaseDate; }

                movieContext.Movies.Update(movie);
                await movieContext.SaveChangesAsync();
                return Results.NoContent();

            });


            //DELETE /movies/id
            group.MapDelete("/{id}", async (int id, MovieContext movieContext) =>
            {
                Movie? movie = await movieContext.Movies.FindAsync(id);

                movieContext.Movies.Remove(movie);
                await movieContext.SaveChangesAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
