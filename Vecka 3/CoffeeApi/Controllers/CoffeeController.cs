
using CoffeeApi.Data;
using CoffeeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeApi.Controllers
{
    [ApiController]
    [Route("api/coffee")]
    public class CoffeeController : ControllerBase
    {
        private readonly CoffeeRepository _repo;

        public CoffeeController(CoffeeRepository repo)
        {
            _repo = repo;
        }

        // GET api/coffee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coffee>>> GetAll()
        {
            var coffees = await _repo.GetAllAsync();
            return Ok(coffees);
        }

        // GET api/coffee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Coffee>> GetById(int id)
        {
            var coffee = await _repo.GetByIdAsync(id);

            if (coffee == null)
                return NotFound();

            return Ok(coffee);
        }

        // POST api/coffee
        [HttpPost]
        public async Task<IActionResult> Create(Coffee coffee)
        {
            await _repo.AddAsync(coffee);
            return Ok();
        }

        // PUT api/coffee/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Coffee updatedCoffee)
        {
            var coffee = await _repo.GetByIdAsync(id);

            if (coffee == null)
                return NotFound();

            coffee.Name = updatedCoffee.Name;
            coffee.Origin = updatedCoffee.Origin;
            coffee.Strength = updatedCoffee.Strength;

            await _repo.UpdateAsync(coffee);
            return Ok();
        }

        // DELETE api/coffee/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var coffee = await _repo.GetByIdAsync(id);

            if (coffee == null)
                return NotFound();

            await _repo.DeleteAsync(coffee);
            return Ok();
        }
    }
}
