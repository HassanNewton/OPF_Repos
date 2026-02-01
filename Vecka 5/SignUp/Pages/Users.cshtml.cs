using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignUp.Data;
using SignUp.Models;
using System.ComponentModel.DataAnnotations;

namespace SignUp.Pages
{
    public class UsersModel : PageModel
    {
        private readonly AppDbContext _context;

        // Dependency Injection av DbContext
        public UsersModel(AppDbContext context)
        {
            _context = context;
        }

        // Lista alla users (visas i tabellen)
        public List<UserModel> Users { get; set; }

        // BindProperty kopplar inputfält till dessa
        [BindProperty]
        [Required]
        public string Username { get; set; }

        [BindProperty]
        [Required, EmailAddress]
        public string Email { get; set; }

        // Körs när sidan laddas
        public async Task OnGetAsync()
        {
            await LoadUsersAsync();
        }

        // Standard POST → skapa användare
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadUsersAsync(); // VIKTIGT
                return Page();
            }
            var user = new UserModel
            {
                Username = Username,
                Email = Email
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        // Handler POST → Delete user
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
        private async Task LoadUsersAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }

}
