using ChalkboardChat.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChalkboardChat.Ui.Pages.Account;

[Authorize]
public class ChangeUsernameModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppDbContext _db;

    public ChangeUsernameModel(
        UserManager<IdentityUser> userManager,
        AppDbContext db)
    {
        _userManager = userManager;
        _db = db;
    }

    [BindProperty]
    public string NewUsername { get; set; } = "";

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToPage("/Index");

        var oldUsername = user.UserName;

        user.UserName = NewUsername;
        user.NormalizedUserName = NewUsername.ToUpper();

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded) return Page();

        var messages = _db.Messages
            .Where(m => m.Username == oldUsername);

        foreach (var msg in messages)
        {
            msg.Username = NewUsername;
        }

        await _db.SaveChangesAsync();

        return RedirectToPage("/Messages/Index");
    }
}
