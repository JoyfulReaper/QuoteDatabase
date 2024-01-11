using QuoteDatabase.Models;

namespace QuoteDatabase.Contracts;

public record SongResponse(int QuoteId, string Text, string AuthorDisplay, string Title, string? Album, string? Artist, int? Track) : QuoteResponse(QuoteId, Text, AuthorDisplay, QuoteType.Song);