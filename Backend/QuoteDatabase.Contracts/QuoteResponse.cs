using QuoteDatabase.Models;

namespace QuoteDatabase.Contracts;

public record QuoteResponse(int QuoteId, string Text, string AuthorDisplay, QuoteType QuoteType);