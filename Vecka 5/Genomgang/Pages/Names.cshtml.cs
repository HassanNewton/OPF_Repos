using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Genomgang.Pages
{
    public class NamesModel : PageModel
    {
        public List<string> Names { get; set; } = new();

        public void OnGet()
        {
            Names = new List<string> { "Ali", "Sara", "John", "Mona" };
        }
    }
}
