using ChalkboardChat.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChalkboardChat.Ui.Pages.Account;

[Authorize]
public class DeleteAccountModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppDbContext _db;

    public DeleteAccountModel(
        UserManager<IdentityUser> userManager,
        AppDbContext db)
    {
        _userManager = userManager;
        _db = db;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToPage("/Index");

        var username = user.UserName;

        var messages = _db.Messages
            .Where(m => m.Username == username);

        foreach (var msg in messages)
        {
            msg.Username = $"{username} (deleted user)";
        }

        await _db.SaveChangesAsync();
        await _userManager.DeleteAsync(user);

        return RedirectToPage("/Index");
    }
}
