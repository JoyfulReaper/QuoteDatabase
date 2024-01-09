using QuoteDatabase.Models;

namespace QuoteDatabase.Repository;

public interface IBookRepository
{
    Task<Book> Add(Book book);
    Task<Book?> Get(int id);
    Task<Book?> Update(Book book);
    Task<bool> Delete(int id);
    Task<IEnumerable<Book>> GetAll();
}