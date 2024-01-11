namespace QuoteDatabase.Models;

public class Song : Quote
{
    public string Title { get; }
    public string Artist { get; }
    public string? Album { get; }
    public int? Track { get; }
    
    public Song(int quoteId, string quoteText, string title, string artist, string? album, int? track)
        : base(quoteId, quoteText, $"{title} by {artist}", QuoteType.Song)
    {
        Title = title;
        Artist = artist;
        Album = album;
        Track = track;
    }
}
