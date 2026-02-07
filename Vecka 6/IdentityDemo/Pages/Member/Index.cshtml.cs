using IdentityDemo.Data_;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityDemo.Pages.Member
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostLogout()
        {
       
            // "SignOutAsync tar bort inloggnings-cookien."
            await _signInManager.SignOutAsync();

            // "Efter logout skickar vi tillbaka till startsidan."
            return RedirectToPage("/Index");
        }
    }
}