namespace QuoteDatabase.Repository.Entities;

public class Person : Quote
{
    public string? FirstName { get; set; }
    public required string LastName { get; set; }
}