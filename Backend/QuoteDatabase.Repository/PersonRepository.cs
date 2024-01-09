using Microsoft.EntityFrameworkCore;
using QuoteDatabase.Repository.Entities;
using Person = QuoteDatabase.Models.Person;

namespace QuoteDatabase.Repository;

public class PersonRepository : IPersonRepository
{
    private readonly QuoteDbContext _context;

    public PersonRepository(QuoteDbContext context)
    {
        _context = context;
    }
    
    public async Task<Person> Add(Person person)
    {
        var entity = person.ToPersonEntity();
        _context.People.Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToPersonModel();
    }

    public async Task<Person?> Get(int id)
    {
        var entity = await _context.People.AsNoTracking().FirstOrDefaultAsync(p => p.QuoteId == id);
        return entity?.ToPersonModel();
    }

    public async Task<Person?> Update(Person person)
    {
        var entity = _context.People.FirstOrDefault(b => b.QuoteId == person.QuoteId);
        if (entity is null) return null;

        entity.QuoteText = person.QuoteText;
        entity.FirstName = person.FirstName;
        entity.LastName = person.LastName;
        
        await _context.SaveChangesAsync();
        return entity.ToPersonModel();
    }

    public async Task<bool> Delete(int id)
    {
        var entity = _context.People.AsNoTracking().FirstOrDefault(p => p.QuoteId == id);
        if (entity is null) return false;

        _context.People.Remove(entity);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<IEnumerable<Person>> GetAll()
    {
        return await _context.People.AsNoTracking().Select(p => p.ToPersonModel()).ToListAsync();
    }
}