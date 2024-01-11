using Microsoft.EntityFrameworkCore;
using QuoteDatabase.Models;
using QuoteDatabase.Repository.Entities;
using Book = QuoteDatabase.Repository.Entities.Book;
using Movie = QuoteDatabase.Repository.Entities.Movie;
using Person = QuoteDatabase.Repository.Entities.Person;
using Quote = QuoteDatabase.Models.Quote;
using Song = QuoteDatabase.Repository.Entities.Song;

namespace QuoteDatabase.Repository;

public class QuoteRepository : IQuoteRepository
{
    private readonly QuoteDbContext _dbContext;

    public QuoteRepository(QuoteDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Quote?> Get(int id)
    {
        var entity = await _dbContext.Quotes.AsNoTracking().FirstOrDefaultAsync(q => q.QuoteId == id);
        switch (entity)
        {
            case Book b:
                return b.ToBookModel();
            case Person p:
                return p.ToPersonModel();
            case Movie m:
                return m.ToMovieModel();
            case Song s:
                return s.ToSongModel();
            default:
                throw new Exception("Unknown type");
        }
    }

    public async Task<Quote> GetRandom()
    {
        int skipper = Random.Shared.Next(0, _dbContext.Quotes.Count());
        var pick = _dbContext.Quotes.Skip(skipper).Take(1).First();
        return pick.ToQuoteModel(pick.QuoteType);
    }

    public async Task<bool> Delete(int id)
    {
        var entity = _dbContext.Quotes.FirstOrDefault(b => b.QuoteId == id);
        if (entity is null) return false;

        _dbContext.Quotes.Remove(entity);
        await _dbContext.SaveChangesAsync();
        
        return true;
    }

    public async Task<IEnumerable<Quote>> GetAll()
    {
        return await _dbContext.Quotes.Select(q => q.ToQuoteModel(q.QuoteType)).ToListAsync();
    }
}