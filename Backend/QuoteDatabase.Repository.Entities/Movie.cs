namespace QuoteDatabase.Repository.Entities;

public class Movie : Quote
{
    public required string Title { get; set; }
    public required string CharacterName { get; set; }
    public string? ActorName { get; set; }
}