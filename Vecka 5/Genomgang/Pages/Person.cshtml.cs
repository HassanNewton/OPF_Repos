using Genomgang.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Genomgang.Pages
{
    public class PersonModel : PageModel
    {
        public Person Person { get; set; } = new();

        public void OnGet()
        {
            Person = new Person
            {
                Name = "Demo Person",
                Age = 22,
                Address = "Malmö"
            };
        }
    }
}
