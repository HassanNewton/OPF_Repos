using IdentityDemo.Data_;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.Pages;
        

public class IndexModel : PageModel

// "UserManager sköter användare (skapa, hitta, lösenord)."
// "SignInManager sköter inloggning (cookie, login/logout)."
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public IndexModel(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [BindProperty, Required]
    public string Username { get; set; }

    [BindProperty, Required]
    public string Password { get; set; }

    public async Task<IActionResult> OnPost()
    {
        //"PasswordSignInAsync kollar användare + lösenord och skapar cookie om det stämmer."
        var result = await _signInManager.PasswordSignInAsync(
            Username, Password, false, false);

        if (result.Succeeded)
            return RedirectToPage("/Member/Index");

        ModelState.AddModelError("", "Invalid login attempt");
        return Page();
    }
}