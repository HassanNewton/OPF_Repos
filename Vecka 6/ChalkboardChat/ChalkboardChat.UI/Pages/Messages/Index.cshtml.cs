using ChalkboardChat.Data.Models;
using ChalkboardChat.Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChalkboardChat.Ui.Pages.Messages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly MessageService _messageService;

    public IndexModel(MessageService messageService)
    {
        _messageService = messageService;
    }

    public List<MessageModel> Messages { get; set; } = new();

    public async Task OnGetAsync()
    {
        Messages = await _messageService.GetAllMessagesAsync();
    }

    public async Task<IActionResult> OnPostAsync(string message)
    {
        if (!string.IsNullOrWhiteSpace(message))
        {
            await _messageService.AddMessageAsync(
                message,
                User.Identity!.Name!
            );
        }

        return RedirectToPage();
    }
}
