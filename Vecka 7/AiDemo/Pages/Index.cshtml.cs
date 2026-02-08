using AiDemo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AiDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AiService _ollama;
        public string Response { get; set; }

        [BindProperty]
        public string Prompt { get; set; }

        public IndexModel(AiService ollama)
        {
            _ollama = ollama;
        }
        public void OnGet()
        {

        }

        public async Task OnPostAsync()
        {
            
            Response = await _ollama.AskAsync(Prompt);
           
        }
    }
}
