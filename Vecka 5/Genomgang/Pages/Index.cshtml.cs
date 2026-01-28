using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Genomgang.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; } = "";

        public void OnGet()
        {
            Message = "Hello from Code Behind!";
        }
    }
}
