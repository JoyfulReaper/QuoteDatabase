using QuoteDatabase.Models;

namespace QuoteDatabase.Repository;

public interface IQuoteRepository
{
    Task<Quote?> Get(int id);
    Task<bool> Delete(int id);
    Task<IEnumerable<Quote>> GetAll();
}