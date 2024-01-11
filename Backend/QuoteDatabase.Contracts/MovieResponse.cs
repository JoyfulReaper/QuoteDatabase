using QuoteDatabase.Models;

namespace QuoteDatabase.Contracts;

public record MovieResponse(int QuoteId, string Text, string AuthorDisplay, string Title, string CharacterName, string? ActorName) : QuoteResponse(QuoteId, Text, AuthorDisplay, QuoteType.Movie);