using Genomgang.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Genomgang.Pages
{
    public class PeopleModel : PageModel
    {
        public List<Person> Persons { get; set; } = new();

        public void OnGet()
        {
            Persons = Genomgang.Data.People.Persons;
        }
    }
}
