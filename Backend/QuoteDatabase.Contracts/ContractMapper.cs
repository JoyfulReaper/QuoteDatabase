namespace QuoteDatabase.Contracts;

public static class ContractMapper
{
    public static Contracts.BookResponse ToContract(this Models.Book bookModel)
    {
        return new Contracts.BookResponse(bookModel.QuoteId,
            bookModel.QuoteText,
            bookModel.DisplayAuthor,
            bookModel.Title, 
            bookModel.Author,
            bookModel.Chapter, 
            bookModel.Page);
    }
    
    public static Contracts.MovieResponse ToContract(this Models.Movie movieModel)
    {
        return new Contracts.MovieResponse(movieModel.QuoteId,
            movieModel.QuoteText,
            movieModel.DisplayAuthor,
            movieModel.Title, 
            movieModel.CharacterName,
            movieModel.ActorName);
    }
    
    public static Contracts.PersonResponse ToContract(this Models.Person personModel)
    {
        return new Contracts.PersonResponse(personModel.QuoteId,
            personModel.QuoteText,
            personModel.DisplayAuthor,
            personModel.FirstName, 
            personModel.LastName);
    }
    
    public static Contracts.SongResponse ToContract(this Models.Song songModel)
    {
        return new Contracts.SongResponse(songModel.QuoteId,
            songModel.QuoteText,
            songModel.DisplayAuthor,
            songModel.Title, 
            songModel.Artist,
            songModel.Album, 
            songModel.Track);
    }

    public static Contracts.QuoteResponse ToContract(this Models.Quote quoteModel)
    {
        return new Contracts.QuoteResponse(quoteModel.QuoteId,
            quoteModel.QuoteText,
            quoteModel.DisplayAuthor);
    }
    
    public static Models.Book ToModel(this Contracts.BookRequest bookContract, int quoteId = 0)
    {
        return new Models.Book(quoteId,
            bookContract.QuoteText,
            bookContract.Title, 
            bookContract.Author,
            bookContract.Chapter, 
            bookContract.Page);
    }
    
    public static Models.Movie ToModel(this Contracts.MovieRequest movieContract, int quoteId = 0)
    {
        return new Models.Movie(quoteId,
            movieContract.QuoteText,
            movieContract.Title, 
            movieContract.CharacterName,
            movieContract.ActorName);
    }
    
    public static Models.Song ToModel(this Contracts.SongRequest songContract, int quoteId = 0)
    {
        return new Models.Song(quoteId,
            songContract.QuoteText,
            songContract.Title, 
            songContract.Artist,
            songContract.Album, 
            songContract.Track);
    }
    
    public static Models.Person ToModel(this Contracts.PersonRequest personContract, int quoteId = 0)
    {
        return new Models.Person(quoteId,
            personContract.QuoteText,
            personContract.FirstName, 
            personContract.LastName);
    }
}