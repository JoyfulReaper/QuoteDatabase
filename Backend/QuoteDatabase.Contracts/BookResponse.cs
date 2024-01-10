namespace QuoteDatabase.Contracts;

public record BookResponse(int QuoteId, string QuoteText, string AuthorDisplay, string Title, string Author, string? Chapter, int? Page) : QuoteResponse(QuoteId, QuoteText, AuthorDisplay);