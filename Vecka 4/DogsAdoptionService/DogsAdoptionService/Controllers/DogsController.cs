using DogsAdoptionService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DogsAdoptionService.Controllers
{
    public class DogsController : Controller
    {
        private static List<DogModel> dogs = new List<DogModel>
        {
            new DogModel{ Id = 1, Name = "Bark Twain", Cuteness = 9, Image = "hund1.jpg", FavFood = "Barkoni", FavToy = "Barkle", Temperament = 7, IsAdopted = false },
            new DogModel{ Id = 2, Name = "Sir Waggington", Cuteness = 8, Image = "hund2.jpg", FavFood = "Pawsta", FavToy = "Fetch Stick", Temperament = 6, IsAdopted = false },
            new DogModel{ Id = 3, Name = "Furball", Cuteness = 6, Image = "hund3.jpg", FavFood = "Bone Appetit", FavToy = "Squeaky Ball", Temperament = 8, IsAdopted = false },
            new DogModel{ Id = 4, Name = "Princess Paws", Cuteness = 10, Image = "hund4.jpg", FavFood = "Royal Canin", FavToy = "Diamond Collar", Temperament = 5, IsAdopted = false },
            new DogModel{ Id = 5, Name = "Biscuit", Cuteness = 7, Image = "Biscuit5.jpg", FavFood = "Pupcakes", FavToy = "Chewy Bone", Temperament = 9, IsAdopted = false },
            new DogModel{ Id = 6, Name = "Daisy", Cuteness = 4, Image = "Daisy6.jpg", FavFood = "Doggie Delight", FavToy = "Plush Squirrel", Temperament = 3, IsAdopted = false },
            new DogModel{ Id = 7, Name = "Captain Woof", Cuteness = 6, Image = "CaptainWoof7.jpg", FavFood = "Fish 'n Chips", FavToy = "Nautical Rope", Temperament = 8, IsAdopted = false },
            new DogModel{ Id = 8, Name = "Snuggle Paws", Cuteness = 9, Image = "SnugglePaws8.jpg", FavFood = "Cuddle Crunchies", FavToy = "Soft Blanket", Temperament = 7, IsAdopted = false },
            new DogModel{ Id = 9, Name = "Rocky", Cuteness = 3, Image = "Rocky9.jpg", FavFood = "Steak Bites", FavToy = "Tennis Ball", Temperament = 4, IsAdopted = false },
            new DogModel{ Id = 10, Name = "Lola", Cuteness = 5, Image = "Lola10.jpg", FavFood = "Treat Tower", FavToy = "Squeaky Duck", Temperament = 6, IsAdopted = false },
            new DogModel{ Id = 11, Name = "Maximus", Cuteness = 8, Image = "Maximus11.jpg", FavFood = "Beefy Bites", FavToy = "Tug Rope", Temperament = 9, IsAdopted = false },
            new DogModel{ Id = 12, Name = "Roxy", Cuteness = 7, Image = "Roxy12.jpg", FavFood = "Chicken Chewies", FavToy = "Frisbee", Temperament = 4, IsAdopted = false },
            new DogModel{ Id = 13, Name = "Teddy", Cuteness = 2, Image = "Teddy13.jpg", FavFood = "Carrot Crunch", FavToy = "Plush Bunny", Temperament = 2, IsAdopted = false },
            new DogModel{ Id = 14, Name = "Coco", Cuteness = 6, Image = "Coco14.jpg", FavFood = "Coconut Chew", FavToy = "Ball Launcher", Temperament = 8, IsAdopted = false }
        };

        // Visar ALLA hundar (med LINQ-sortering)
        public IActionResult Index()
        {
            var sortedDogs = dogs.OrderBy(d => d.Name).ToList();
            return View(sortedDogs);
        }

        // Visar en specifik hund
        public IActionResult Details(int id)
        {
            var dog = dogs.FirstOrDefault(d => d.Id == id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        public IActionResult Adopt(int id)
        {
            var dog = dogs.FirstOrDefault(d => d.Id == id);
            if (dog == null)
            {
                return NotFound();
            }

            // Markera hunden som adopterad
            dog.IsAdopted = true;

            return View(dog);
        }
    }
}
