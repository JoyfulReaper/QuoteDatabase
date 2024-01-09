using Microsoft.EntityFrameworkCore;

namespace QuoteDatabase.Repository.Entities;

public class QuoteDbContext : DbContext
{
    public DbSet <Quote> Quotes { get; set; } = null!;
    public DbSet <Movie> Movies { get; set; } = null!;
    public DbSet <Song> Songs { get; set; } = null!;
    public DbSet <Person> People { get; set; } = null!;
    public DbSet <Book> Books { get; set; } = null!;
    
    public QuoteDbContext(DbContextOptions<QuoteDbContext> options) : base (options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quote>()
            .Property(x => x.QuoteText)
            .IsRequired()
            .HasMaxLength(2000);
        
        modelBuilder.Entity<Movie>()
            .HasBaseType<Quote>();
        
        modelBuilder.Entity<Movie>()
            .Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(255);
        
        modelBuilder.Entity<Movie>()
            .Property(x => x.CharacterName)
            .IsRequired()
            .HasMaxLength(255);
        
        modelBuilder.Entity<Movie>()
            .Property(x => x.ActorName)
            .HasMaxLength(255);
        
        modelBuilder.Entity<Song>()
            .HasBaseType<Quote>();
        
        modelBuilder.Entity<Song>()
            .Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(255);
        
        modelBuilder.Entity<Song>()
            .Property(x => x.Artist)
            .IsRequired()
            .HasMaxLength(255);
        
        modelBuilder.Entity<Song>()
            .Property(x => x.Album)
            .IsRequired()
            .HasMaxLength(255);
        
        
        modelBuilder.Entity<Person>()
            .HasBaseType<Quote>();
        
        modelBuilder.Entity<Person>()
            .Property(x => x.FirstName)
            .HasMaxLength(255);
        
        modelBuilder.Entity<Person>()
            .Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(255);
        
        modelBuilder.Entity<Book>()
            .Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(255);
        
        modelBuilder.Entity<Book>()
            .Property(x => x.Author)
            .IsRequired()
            .HasMaxLength(255);
        
        modelBuilder.Entity<Book>()
            .Property(x => x.Chapter)
            .HasMaxLength(255);
        
        modelBuilder.Entity<Book>()
            .HasBaseType<Quote>();
    }
}