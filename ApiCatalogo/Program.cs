using ApiCatalogo.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.//ConfigureServices
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 

builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseMySql(connectionString, 
                 ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

app.MapControllers();

//definir os endpoints
//app.MapGet("/", () => "Catálogo de Volumes - 2022").ExcludeFromDescription();

//app.MapPost("/orders", async (Order order, AppDbContext db)
// => {
//     db.Orders.Add(order);
//     await db.SaveChangesAsync();

//     return Results.Created($"/orders/{order.OrderId}", order);
// });


//app.MapGet("/orders", async (AppDbContext db) => await db.Orders.ToListAsync());

//app.MapGet("/orders/{id:int}", async (int id, AppDbContext db)
//    => {
//        return await db.Orders.FindAsync(id)
//                     is Order order
//                     ? Results.Ok(order)
//                     : Results.NotFound();
//    });

//app.MapPut("/orders/{id:int}", async (int id, Order order, AppDbContext db) =>
//{

//    if (order.OrderId != id)
//    {
//        return Results.BadRequest();
//    }

//    var orderDB = await db.Orders.FindAsync(id);

//    if (orderDB is null) return Results.NotFound();

//    orderDB.Nome = order.Nome;
//    orderDB.Descricao = order.Descricao;

//    await db.SaveChangesAsync();

//    return Results.Ok(orderDB);
//});

//app.MapDelete("/orders/{id:int}", async (int id, AppDbContext db) =>
//{
//    var order = await db.Orders.FindAsync(id);

//    if (order is null)
//    {
//        return Results.NotFound();
//    }

//    db.Orders.Remove(order);
//    await db.SaveChangesAsync();

//    return Results.NoContent();
//});

////------------------------endpoints para Volume ---------------------------------
//app.MapPost("/volumes", async (Volume volume, AppDbContext db)
// => {
//     db.Volumes.Add(volume);
//     await db.SaveChangesAsync();

//     return Results.Created($"/volumes/{volume.VolumeId}", volume);
// });

//app.MapGet("/volumes", async (AppDbContext db) => await db.Volumes.ToListAsync());

//app.MapGet("/volumes/{id:int}", async (int id, AppDbContext db)
//    => {
//        return await db.Volumes.FindAsync(id)
//                     is Volume volume
//                     ? Results.Ok(volume)
//                     : Results.NotFound();
//    });

//app.MapPut("/volumes/{id:int}", async (int id, Volume volume, AppDbContext db) =>
//{

//    if (volume.VolumeId != id)
//    {
//        return Results.BadRequest();
//    }

//    var volumeDB = await db.Volumes.FindAsync(id);

//    if (volumeDB is null) return Results.NotFound();

//    volumeDB.Nome = volume.Nome;
//    volumeDB.Descricao = volume.Descricao;
//    volumeDB.Preco = volume.Preco;
//    volumeDB.Imagem = volume.Imagem;
//    volumeDB.DataCompra = volume.DataCompra;
//    volumeDB.Estoque = volume.Estoque;
//    volumeDB.OrderId = volume.OrderId;

//    await db.SaveChangesAsync();

//    return Results.Ok(volumeDB);
//});

//app.MapDelete("/volumes/{id:int}", async (int id, AppDbContext db) =>
//{
//    var volume = await db.Volumes.FindAsync(id);

//    if (volume is null)
//    {
//        return Results.NotFound();
//    }

//    db.Volumes.Remove(volume);
//    await db.SaveChangesAsync();

//    return Results.NoContent();
//});


// Configure the HTTP request pipeline.//Configure
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();