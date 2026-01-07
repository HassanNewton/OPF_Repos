using ChalkboardChat.Data.Contexts;
using ChalkboardChat.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ChalkboardChat.Logic.Services;

public class MessageService
{
    private readonly AppDbContext _db;

    public MessageService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<MessageModel>> GetAllMessagesAsync()
    {
        return await _db.Messages
            .OrderByDescending(m => m.Date)
            .ToListAsync();
    }

    public async Task AddMessageAsync(string message, string username)
    {
        var msg = new MessageModel
        {
            Message = message,
            Username = username,
            Date = DateTime.UtcNow
        };

        _db.Messages.Add(msg);
        await _db.SaveChangesAsync();
    }
}