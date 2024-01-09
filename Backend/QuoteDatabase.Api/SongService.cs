using QuoteDatabase.Contracts;
using QuoteDatabase.Models;
using QuoteDatabase.Repository;

namespace QuoteDatabase.Api;

public static class SongService
{
    public static WebApplication AddSongEndpoints(this WebApplication app)
    {
        app.MapGet("/api/quotes/songs", async (ISongRepository songRepository, HttpContext httpContext) =>
        {
            var allSongs = await songRepository.GetAll();
            
            return Results.Ok(allSongs.Select(s => s.ToContract()));
        });
    
        app.MapGet("/api/quotes/songs/{id}", async (int id, ISongRepository songRepository, HttpContext httpContext) =>
        {
            var song = await songRepository.Get(id);
            if (song is null)
                return Results.NotFound();
        
            return Results.Ok(song.ToContract());
        });
        

        app.MapPost("/api/quotes/songs", async (SongRequest song, ISongRepository bookRepository, HttpContext httpContext) =>
        {
            var result = await bookRepository.Add(song.ToModel());
            
            return Results.Created($"/songs/{result.QuoteId}", result.ToContract());
        });
    
        app.MapPut("/api/quotes/songs/{id}", async (int id, SongRequest song, ISongRepository songRepository) =>
        {
            var songDb = await songRepository.Get(id);
            if (songDb is null)
                return Results.NotFound();

            await songRepository.Update(song.ToModel(id));
            return Results.NoContent();
        });

        app.MapDelete("/api/quotes/songs/{id}", async (int id, ISongRepository songRepository, HttpContext httpContext) =>
        {
            var result = await songRepository.Delete(id);
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