namespace QuoteDatabase.Contracts;

public record PersonResponse (int QuoteId, string Text, string DisplayAuthor, string? FirstName, string LastName) : QuoteResponse(QuoteId, Text, DisplayAuthor);