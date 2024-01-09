namespace QuoteDatabase.Repository.Entities;

public class Song : Quote
{
    public required string Title { get; set; }
    public required string Artist { get; set; }
    public string? Album { get; set; }
    public int? Track { get; set; }
}