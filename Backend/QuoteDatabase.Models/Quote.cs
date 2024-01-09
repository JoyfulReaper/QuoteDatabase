namespace QuoteDatabase.Models;

public class Quote
{
    public int QuoteId { get; }
    public string QuoteText { get; }
    public virtual string DisplayAuthor { get; } = "(Unknown)";
    public Quote(int quoteId, string quoteText, string displayAuthor)
    {
        QuoteId = quoteId;
        QuoteText = quoteText;
        DisplayAuthor = displayAuthor;
    }
}