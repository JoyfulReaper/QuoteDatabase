namespace QuoteDatabase.Contracts;

public record PersonResponse (int QuoteId, string Text, string AuthorDisplay, string? FirstName, string LastName) : QuoteResponse(QuoteId, Text, AuthorDisplay);