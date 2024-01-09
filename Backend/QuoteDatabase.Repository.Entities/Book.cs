namespace QuoteDatabase.Repository.Entities;

public class Book : Quote
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public string? Chapter { get; set; }
    public int? Page { get; set; }
}