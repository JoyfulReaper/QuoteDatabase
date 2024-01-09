namespace QuoteDatabase.Contracts;

public record BookResponse(int QuoteId, string QuoteText, string DisplayAuthor, string Title, string Author, string? Chapter, int? Page) : QuoteResponse(QuoteId, QuoteText, DisplayAuthor);