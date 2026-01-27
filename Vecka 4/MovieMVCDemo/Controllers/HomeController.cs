using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace MovieMVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


//Skapa en controller ex ColorsController
//Skapa action metoder som returnerar VIEWS
//Skapa en view mapp med samma namn som controllern under VIEW mappen
//VIKTIGT: se till att ha views med samma namn som action under views mappen
//I dem olika views filerna kan man länka till nästa view mha asp-controller och asp-action
//Lägg in i layout filen för att kunna navigera till Colors

//asp-action = vilken metod? 
//asp-controller = vilken controller/klass
//asp-route-id = vilket värde som skickas (parameter)
//asp-for koppa/binda input till modellen

//BOOTSTRAP FÄRG KLASSER
//bg-primary = blå
//bg-sucess = grön
//bg-warning = Gul
//bg-danger = Röd