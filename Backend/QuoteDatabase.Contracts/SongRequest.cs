namespace QuoteDatabase.Contracts;

public record SongRequest(string Text, string Title, string Artist, string? Album, int? Track) : QuoteRequest(Text);