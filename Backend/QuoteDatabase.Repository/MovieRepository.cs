using Microsoft.EntityFrameworkCore;
using QuoteDatabase.Repository.Entities;
using Movie = QuoteDatabase.Models.Movie;

namespace QuoteDatabase.Repository;

public class MovieRepository : IMovieRepository
{
    private readonly QuoteDbContext _context;

    public MovieRepository(QuoteDbContext context)
    {
        _context = context;
    }
    
    public async Task<Movie> Add(Movie movie)
    {
        var entitiy = movie.ToMovieEntity();
        _context.Movies.Add(entitiy);
        await _context.SaveChangesAsync();
        return entitiy.ToMovieModel();
    }

    public async Task<Movie?> Get(int id)
    {
        var entity = await _context.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.QuoteId == id);
        return entity?.ToMovieModel();
    }

    public async Task<Movie?> Update(Movie movie)
    {
        var entity = _context.Movies.FirstOrDefault(b => b.QuoteId == movie.QuoteId);
        if (entity is null) return null;

        entity.QuoteText = movie.QuoteText;
        entity.Title = movie.Title;
        entity.CharacterName = movie.CharacterName;
        entity.ActorName = movie.ActorName;
        
        await _context.SaveChangesAsync();
        return entity.ToMovieModel();
    }

    public async Task<bool> Delete(int id)
    {
        var entity = _context.Movies.AsNoTracking().FirstOrDefault(m => m.QuoteId == id);
        if (entity is null) return false;

        _context.Movies.Remove(entity);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<IEnumerable<Movie>> GetAll()
    {
        return await _context.Movies.Select(m => m.ToMovieModel()).ToListAsync();
    }
}