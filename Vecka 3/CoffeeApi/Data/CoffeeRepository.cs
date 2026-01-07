using CoffeeApi.Data;
using CoffeeApi.Models;
using Microsoft.EntityFrameworkCore;
using CoffeeApi.Models;

namespace CoffeeApi.Data
{
    // Repository = Data Access Layer (DAL)
    public class CoffeeRepository
    {
        private readonly CoffeeDbContext _context;

        public CoffeeRepository(CoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Coffee>> GetAllAsync()
        {
            return await _context.Coffees.ToListAsync();
        }

        public async Task<Coffee?> GetByIdAsync(int id)
        {
            return await _context.Coffees.FindAsync(id);
        }

        public async Task AddAsync(Coffee coffee)
        {
            _context.Coffees.Add(coffee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Coffee coffee)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Coffee coffee)
        {
            _context.Coffees.Remove(coffee);
            await _context.SaveChangesAsync();
        }
    }
}
