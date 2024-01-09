using QuoteDatabase.Models;
using QuoteDatabase.Repository;
using QuoteDatabase.Contracts;

namespace QuoteDatabase.Api;

public static class MovieService
{
    public static WebApplication AddMovieEndpoints(this WebApplication app)
    {
        app.MapGet("/api/quotes/movies", async (IMovieRepository movieRepository, HttpContext httpContext) =>
        {
            var allMovies = await movieRepository.GetAll();
            
            return Results.Ok(allMovies.Select(m => m.ToContract()));
        });
    
        app.MapGet("/api/quotes/movies/{id}", async (int id, IMovieRepository movieRepository, HttpContext httpContext) =>
        {
            var movie = await movieRepository.Get(id);
            if (movie is null)
                return Results.NotFound();
        
            return Results.Ok(movie.ToContract());
        });
        

        app.MapPost("/api/quotes/movies", async (MovieRequest movie, IMovieRepository movieRepository, HttpContext httpContext) =>
        {
            var result = await movieRepository.Add(movie.ToModel());
            
            return Results.Created($"/movies/{result.QuoteId}", result.ToContract());
        });
    
        app.MapPut("/api/quotes/movies/{id}", async (int id, MovieRequest movie, IMovieRepository movieRepository) =>
        {
            var bookDb = await movieRepository.Get(id);
            if (bookDb is null)
                return Results.NotFound();

            await movieRepository.Update(movie.ToModel(id));
            return Results.NoContent();
        });

        app.MapDelete("/api/quotes/movies/{id}", async (int id, IMovieRepository movieRepository, HttpContext httpContext) =>
        {
            var result = await movieRepository.Delete(id);
            if (!result)
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            httpContext.Response.StatusCode = StatusCodes.Status204NoContent;
        });
    
        return app; 
    }
}