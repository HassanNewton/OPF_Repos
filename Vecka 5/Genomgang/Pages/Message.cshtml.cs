using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Genomgang.Pages
{
    public class MessageModel : PageModel
    {
        public string Text { get; set; } = "";

        public void OnGet(string? text)
        {
            Text = string.IsNullOrWhiteSpace(text) ? "Ingen text skickades." : text;
        }
    }
}
