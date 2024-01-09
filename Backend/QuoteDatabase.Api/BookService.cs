using QuoteDatabase.Models;
using QuoteDatabase.Repository;
using QuoteDatabase.Contracts;

namespace QuoteDatabase.Api;

public static class BookService
{
    public static WebApplication AddBookEndpoints(this WebApplication app)
    {
        app.MapGet("/api/quotes/books", async (IBookRepository bookRepository, HttpContext httpContext) =>
        {
            var allBooks = await bookRepository.GetAll();
            
            
            return Results.Ok(allBooks.Select(b => b.ToContract()));
        });
    
        app.MapGet("/api/quotes/books/{id}", async (int id, IBookRepository bookRepository, HttpContext httpContext) =>
        {
            var book = await bookRepository.Get(id);
            if (book is null)
                return Results.NotFound();
        
            return Results.Ok(book.ToContract());
        });
        

        app.MapPost("/api/quotes/books", async (Contracts.BookRequest bookRequest, IBookRepository bookRepository, HttpContext httpContext) =>
        {
            var result = await bookRepository.Add(bookRequest.ToModel());
            
            return Results.Created($"/books/{result.QuoteId}", result.ToContract());
        });
    
        app.MapPut("/api/quotes/books/{id}", async (int id, BookRequest book, IBookRepository bookRepository) =>
        {
            var bookDb = await bookRepository.Get(id);
            if (bookDb is null)
                return Results.NotFound();

            await bookRepository.Update(book.ToModel(id));
            return Results.NoContent();
        });

        app.MapDelete("/api/quotes/books/{id}", async (int id, IBookRepository bookRepository, HttpContext httpContext) =>
        {
            var result = await bookRepository.Delete(id);
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