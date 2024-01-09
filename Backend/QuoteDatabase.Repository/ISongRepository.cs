using QuoteDatabase.Models;

namespace QuoteDatabase.Repository;

public interface ISongRepository
{
    Task<Song> Add(Song song);
    Task<Song?> Get(int id);
    Task<Song?> Update(Song song);
    Task<bool> Delete(int id);
    Task<IEnumerable<Song>> GetAll();
}