using Microsoft.EntityFrameworkCore;
using QuoteDatabase.Repository.Entities;
using Song = QuoteDatabase.Models.Song;

namespace QuoteDatabase.Repository;

public class SongRepository : ISongRepository
{
    private readonly QuoteDbContext _context;

    public SongRepository(QuoteDbContext context)
    {
        _context = context;
    }
    
    public async Task<Song> Add(Song song)
    {
        var entity = song.ToSongEntity();
        _context.Songs.Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToSongModel();
    }

    public async Task<Song?> Get(int id)
    {
        var entity = await _context.Songs.AsNoTracking().FirstOrDefaultAsync(b => b.QuoteId == id);
        return entity?.ToSongModel();
    }

    public async Task<Song?> Update(Song song)
    {
        var entity = _context.Songs.FirstOrDefault(b => b.QuoteId == song.QuoteId);
        if (entity is null) return null;

        entity.QuoteText = song.QuoteText;
        entity.Title = song.Title;
        entity.Artist = song.Artist;
        entity.Album = song.Album;
        entity.Track = song.Track;
        
        await _context.SaveChangesAsync();
        return entity.ToSongModel();
    }

    public async Task<bool> Delete(int id)
    {
        var entity = _context.Songs.AsNoTracking().FirstOrDefault(b => b.QuoteId == id);
        if (entity is null) return false;

        _context.Songs.Remove(entity);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<IEnumerable<Song>> GetAll()
    {
        return await _context.Songs.AsNoTracking().Select(b => b.ToSongModel()).ToListAsync();
    }
}