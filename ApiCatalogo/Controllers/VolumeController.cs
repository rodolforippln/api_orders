using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers;

[ApiController]
[Route("api/v1/volumes")]
public class VolumeController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Volume>> GetAll([FromServices] AppDbContext db)
    {
        return await db.Volumes.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Createasync([FromBody] Volume volume, [FromServices] AppDbContext db)
    {
        db.Volumes.Add(volume);
        await db.SaveChangesAsync();

        return Created($"/volumes/{volume.VolumeId}", volume);
    }

    //[HttpGet]
    //[Route("v1/categories")]
    //public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
    //{
    //    var categories = await context.Categories
    //        .AsNoTracking()
    //        .ToListAsync();
    //    return Ok(categories);
    //}

    //[HttpGet]
    //[Route("v1/categories/{id:int}")]
    //public async Task<IActionResult> GetByIdAsync(
    //    [FromRoute] int Id,
    //    [FromServices] BlogDataContext context)
    //{
    //    var category = await context.Categories
    //        .AsNoTracking()
    //        .FirstOrDefaultAsync(x => x.Id == Id);

    //    if (category == null)
    //        return NotFound();

    //    return Ok(category);
    //}

    //[HttpPost]
    //[Route("v1/categories")]
    //public async Task<IActionResult> PostAsync(
    //    [FromBody] Category category,
    //    [FromServices] BlogDataContext context)
    //{
    //    try
    //    {
    //        await context.Categories
    //        .AddAsync(category);

    //        await context.SaveChangesAsync();

    //        return Created($"v1/categories/{category.Id}", category);
    //    }
    //    catch (DbUpdateException ex)
    //    {
    //        return StatusCode(500, "Não foi possível incluír a categoria");
    //    }
    //    catch (Exception ex)
    //    {

    //        return StatusCode(500, "Falha interna no servidor");
    //    }
    //}

    //[HttpPut]
    //[Route("v1/categories/{id:int}")]
    //public async Task<IActionResult> UpdateAsync(
    //    [FromRoute] int Id,
    //    [FromBody] Category model,
    //    [FromServices] BlogDataContext context)
    //{
    //    var category = await context.Categories
    //        .FirstOrDefaultAsync(x => x.Id == Id);

    //    if (category == null)
    //        return NotFound();

    //    category.Name = model.Name;
    //    category.Slug = model.Slug;

    //    context.Categories.Update(category);
    //    await context.SaveChangesAsync();

    //    return Ok(category);
    //}

    //[HttpDelete]
    //[Route("v1/categories/{id:int}")]
    //public async Task<IActionResult> DeleteAsync(
    //    [FromRoute] int Id,
    //    [FromServices] BlogDataContext context)
    //{
    //    var category = await context.Categories.FirstAsync(x => x.Id == Id);

    //    if (category == null)
    //        return NotFound();

    //    context.Categories.Remove(category);
    //    await context.SaveChangesAsync();

    //    return Ok(category);
    //}
}
