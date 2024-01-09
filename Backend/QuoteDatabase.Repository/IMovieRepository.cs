using QuoteDatabase.Models;

namespace QuoteDatabase.Repository;

public interface IMovieRepository
{
    Task<Movie> Add(Movie movie);
    Task<Movie?> Get(int id);
    Task<Movie?> Update(Movie movie);
    Task<bool> Delete(int id);
    Task<IEnumerable<Movie>> GetAll();
}