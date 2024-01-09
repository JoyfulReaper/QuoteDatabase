namespace QuoteDatabase.Contracts;

public record MovieRequest(string Text, string Title, string CharacterName, string? ActorName) : QuoteRequest(Text);