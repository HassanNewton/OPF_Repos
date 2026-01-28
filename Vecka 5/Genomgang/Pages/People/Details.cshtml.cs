using Genomgang.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Genomgang.Pages.People
{
    public class DetailsModel : PageModel
    {
        public Person? Person { get; set; }

        public void OnGet(int id)
        {
            Person = Genomgang.Data.People.GetById(id);
        }
    }
}
