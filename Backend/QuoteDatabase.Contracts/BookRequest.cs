namespace QuoteDatabase.Contracts;

public record BookRequest(string Text, string Title, string Author, string? Chapter, int? Page) : QuoteRequest(Text);