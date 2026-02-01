using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignUp.Data;
using SignUp.Models;

namespace SignUp.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public UserModel User { get; set; }

        public async Task OnGetAsync(int id)
        {
            User = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
