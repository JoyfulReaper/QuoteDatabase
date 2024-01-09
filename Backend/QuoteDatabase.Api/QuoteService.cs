using QuoteDatabase.Contracts;
using QuoteDatabase.Repository;

namespace QuoteDatabase.Api;

public static class QuoteService
{
    public static WebApplication AddQuoteEndpoints(this WebApplication app)
    {
        app.MapGet("/api/quotes", async (IQuoteRepository quoteRepository, HttpContext httpContext) =>
        {
            var allQuotes = await quoteRepository.GetAll();
            
            return Results.Ok(allQuotes.Select(q => q.ToContract()));
        });
        
        app.MapGet("/api/quotes/{id}", async (int id, IQuoteRepository quoteRepository, HttpContext httpContext) =>
        {
            var quote = await quoteRepository.Get(id);
            if (quote is null)
                return Results.NotFound();
        
            return Results.Ok(quote.ToContract());
        });
        
        app.MapDelete("/api/quotes/{id}", async (int id, IQuoteRepository quoteRepository, HttpContext httpContext) =>
        {
            var result = await quoteRepository.Delete(id);
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