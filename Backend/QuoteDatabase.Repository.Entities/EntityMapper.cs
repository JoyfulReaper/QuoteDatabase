using QuoteDatabase.Models;

namespace QuoteDatabase.Repository.Entities;

public static class EntityMapper
{
    public static Entities.Book ToBookEntity(this Models.Book book)
    {
        return new Entities.Book
        {
            QuoteId = book.QuoteId,
            QuoteText = book.QuoteText,
            Title = book.Title,
            Author = book.Author,
            Chapter = book.Chapter,
            Page = book.Page,
            DisplayAuthor = book.DisplayAuthor
        };
    }
    
    public static Entities.Movie ToMovieEntity(this Models.Movie movie)
    {
        return new Entities.Movie
        {
            QuoteId = movie.QuoteId,
            QuoteText = movie.QuoteText,
            Title = movie.Title,
            CharacterName = movie.CharacterName,
            ActorName = movie.ActorName,
            DisplayAuthor = movie.DisplayAuthor
        };
    }
    
    public static Entities.Person ToPersonEntity(this Models.Person person)
    {
        return new Entities.Person
        {
            QuoteId = person.QuoteId,
            QuoteText = person.QuoteText,
            FirstName = person.FirstName,
            LastName = person.LastName,
            DisplayAuthor = person.DisplayAuthor
        };
    }
    
    public static Entities.Song ToSongEntity(this Models.Song song)
    {
        return new Entities.Song
        {
            QuoteId = song.QuoteId,
            QuoteText = song.QuoteText,
            Title = song.Title,
            Artist = song.Artist,
            Album = song.Album,
            Track = song.Track,
            DisplayAuthor = song.DisplayAuthor
        };
    }
    
    public static Entities.Quote ToQuoteEntity(this Models.Quote quote)
    {
        return new Entities.Quote
        {
            QuoteId = quote.QuoteId,
            QuoteText = quote.QuoteText,
            DisplayAuthor = quote.DisplayAuthor
        };
    }

    public static Models.Quote ToQuoteModel(this Entities.Quote quote, QuoteType quoteType = QuoteType.Unknown)
    {
        return new Models.Quote(quote.QuoteId, quote.QuoteText, quote.DisplayAuthor, quoteType);
    }

    public static Models.Book ToBookModel(this Entities.Book book)
    {
        return new Models.Book(book.QuoteId, book.QuoteText, book.Title, book.Author, book.Chapter, book.Page);
    }
    
    public static Models.Movie ToMovieModel(this Entities.Movie movie)
    {
        return new Models.Movie(movie.QuoteId, movie.QuoteText, movie.Title, movie.CharacterName, movie.ActorName);
    }
    
    public static Models.Person ToPersonModel(this Entities.Person person)
    {
        return new Models.Person(person.QuoteId, person.QuoteText, person.FirstName, person.LastName);
    }
    
    public static Models.Song ToSongModel(this Entities.Song song)
    {
        return new Models.Song(song.QuoteId, song.QuoteText, song.Title, song.Artist, song.Album, song.Track);
    }
}