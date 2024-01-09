namespace QuoteDatabase.Repository.Entities;

public class Quote
{
    public int QuoteId { get; set; }
    public required string QuoteText { get; set; }
    public required string DisplayAuthor { get; set; }
}