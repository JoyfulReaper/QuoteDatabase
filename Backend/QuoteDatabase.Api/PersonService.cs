using QuoteDatabase.Contracts;
using QuoteDatabase.Repository;

namespace QuoteDatabase.Api;

public static class PersonService
{
    public static WebApplication AddPersonEndpoints(this WebApplication app)
    {
        app.MapGet("/api/quotes/people", async (IPersonRepository person, HttpContext httpContext) =>
        {
            var allPeople = await person.GetAll();
            
            return Results.Ok(allPeople.Select(p => p.ToContract()));
        });
    
        app.MapGet("/api/quotes/people/{id}", async (int id, IPersonRepository personRepository, HttpContext httpContext) =>
        {
            var person = await personRepository.Get(id);
            if (person is null)
                return Results.NotFound();
        
            return Results.Ok(person.ToContract());
        });
        

        app.MapPost("/api/quotes/people", async (PersonRequest person, IPersonRepository personRepository, HttpContext httpContext) =>
        {
            var result = await personRepository.Add(person.ToModel());
            
            return Results.Created($"/books/{result.QuoteId}", result.ToContract());
        });
    
        app.MapPut("/api/quotes/people/{id}", async (int id, PersonRequest person, IPersonRepository personRepository) =>
        {
            var personDb = await personRepository.Get(id);
            if (personDb is null)
                return Results.NotFound();

            await personRepository.Update(person.ToModel(id));
            return Results.NoContent();
        });

        app.MapDelete("/api/quotes/people/{id}", async (int id, IPersonRepository personRepository, HttpContext httpContext) =>
        {
            var result = await personRepository.Delete(id);
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