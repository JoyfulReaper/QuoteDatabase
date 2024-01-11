namespace QuoteDatabase.Models;

public class Movie : Quote
{
    public string Title { get; set; }
    public string CharacterName { get; set; }
    public string? ActorName { get; set; }
    
    public Movie(int quoteId, string quoteText, string title, string characterName, string? actorName)
        : base (quoteId, quoteText, $"{characterName}, {title}", QuoteType.Movie)
    {
        Title = title;
        CharacterName = characterName;
        ActorName = actorName;
    }
}