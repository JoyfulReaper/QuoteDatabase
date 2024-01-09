namespace QuoteDatabase.Models;

public class Book : Quote
{
    public string Title { get; }
    public string Author { get; }
    public string? Chapter { get; }
    public int? Page { get; }

    public Book(int quoteId, string quoteText, string title, string author, string? chapter, int? page) 
        : base (quoteId, quoteText, $"{title} by {author}")
    {
        Title = title;
        Author = author;
        Chapter = chapter;
        Page = page;
    }
}