using Microsoft.EntityFrameworkCore;
using QuoteDatabase.Repository.Entities;
using Book = QuoteDatabase.Models.Book;

namespace QuoteDatabase.Repository;

public class BookRepository : IBookRepository
{
    private readonly QuoteDbContext _context;

    public BookRepository(QuoteDbContext context)
    {
        _context = context;
    }
    
    public async Task<Book> Add(Book book)
    {
        var entity = book.ToBookEntity();
        _context.Books.Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToBookModel();
    }

    public async Task<Book?> Get(int id)
    {
        var entity = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.QuoteId == id);
        return entity?.ToBookModel();
    }

    public async Task<Book?> Update(Book book)
    {
        var entity = _context.Books.FirstOrDefault(b => b.QuoteId == book.QuoteId);
        if (entity is null) return null;
        
        entity.QuoteText = book.QuoteText;
        entity.Title = book.Title;
        entity.Author = book.Author;
        entity.Chapter = book.Chapter;
        entity.Page = book.Page;
        
        await _context.SaveChangesAsync();
        return entity.ToBookModel();
    }

    public async Task<bool> Delete(int id)
    {
        var entity = _context.Books.AsNoTracking().FirstOrDefault(b => b.QuoteId == id);
        if (entity is null) return false;

        _context.Books.Remove(entity);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _context.Books.AsNoTracking().Select(b => b.ToBookModel()).ToListAsync();
    }
}