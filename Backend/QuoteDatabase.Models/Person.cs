namespace QuoteDatabase.Models;

public class Person : Quote
{
    public string? FirstName { get; set; }
    public string LastName { get; set; }
    
    public Person(int quoteId, string quoteText, string firstName, string lastName) : base(quoteId, quoteText,$"{firstName} {lastName}" )
    {
        FirstName = firstName;
        LastName = lastName;
    }
}