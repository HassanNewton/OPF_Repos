using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantBooking.Models;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Pages
{
    public class BookTableModel : PageModel
    {
        [BindProperty]
        public Booking Booking { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // visa samma sida igen med fel
            }

            // Här hade man sparat i databas

            return RedirectToPage("/Confirmation");
        }
    }
}

//[BindProperty] → gör POST möjlig

//ModelState.IsValid → validerar [Required]

//RedirectToPage() → skickar vidare efter POST (PRG-mönstret)
