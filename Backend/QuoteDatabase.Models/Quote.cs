namespace QuoteDatabase.Models;

public class Quote
{
    public int QuoteId { get; }
    public string QuoteText { get; }
    public virtual string DisplayAuthor { get; } = "(Unknown)";
    public virtual QuoteType QuoteType { get; } = QuoteType.Unknown;
    
    public Quote(int quoteId, string quoteText, string displayAuthor, QuoteType quoteType)
    {
        QuoteId = quoteId;
        QuoteText = quoteText;
        DisplayAuthor = displayAuthor;
        QuoteType = quoteType;
    }
}