namespace QuoteDatabase.Contracts;

public record PersonRequest(string Text, string? FirstName, string LastName) : QuoteRequest(Text);