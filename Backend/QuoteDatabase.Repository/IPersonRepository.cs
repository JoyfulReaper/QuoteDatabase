using QuoteDatabase.Models;

namespace QuoteDatabase.Repository;

public interface IPersonRepository
{
    Task<Person> Add(Person person);
    Task<Person?> Get(int id);
    Task<Person?> Update(Person person);
    Task<bool> Delete(int id);
    Task<IEnumerable<Person>> GetAll();
}