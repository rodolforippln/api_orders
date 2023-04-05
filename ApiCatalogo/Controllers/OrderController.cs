using ApiCatalogo.Context;
using ApiCatalogo.Models;
using ApiCatalogo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers;

[ApiController]
[Route("api/v1/orders")]
public class OrderController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Order>> GetAll([FromServices] AppDbContext db)
    {
        return await db.Orders.AsNoTracking().ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Createasync([FromBody] CreateOrderViewModel model, [FromServices] AppDbContext db)
    {
        var order = new Order
        {
            OrderId = model.OrderId,
            OriginPointCode = model.OriginPartnerPointCode,
            OriginPartnerPointCode = model.OriginPartnerPointCode,
            OriginPostalCode = model.OriginPostalCode,
            ToCollect = model.ToCollect
        };

        db.Orders.Add(order);
        await db.SaveChangesAsync();

        return Created($"/api/v1/orders/{order.OrderId}", order);
    }    
}
