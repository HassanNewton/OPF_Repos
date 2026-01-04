using Microsoft.AspNetCore.Mvc;
using TechShop.Api;
using TechShop.Api.Dtos;

namespace TechShop.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _db;

    public OrdersController(AppDbContext db)
    {
        _db = db;
    }

    // POST api/orders
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
    {
        var order = new Order
        {
            OrderDate = dto.OrderDate
        };

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public IEnumerable<Order> GetOrders()
    {
        return _db.Orders.ToList();
    }
}
