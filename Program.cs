using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoEF.Models;
using proyectoEF;    
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p =>p.UseInMemoryDatabase("TareasDB"));
var connectionString = builder.Configuration.GetConnectionString("StringConection");

builder.Services.AddSqlServer<TareasContext>(connectionString);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory() );
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    
    return Results.Ok(dbContext.Tareas.Include(t => t.Categoria));
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/api/tareas/{guid}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea,[FromRoute] Guid guid) =>
{

    var work = await dbContext.Tareas.FindAsync(guid);
    if (work is null) return Results.NotFound();
    work.Titulo = tarea.Titulo;
    work.CategoriaId = tarea.CategoriaId;
    work.Descripcion = tarea.Descripcion;
    work.PrioridadTarea = tarea.PrioridadTarea;
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});
app.MapPut("/api/categoria/{guid}", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria,[FromRoute] Guid guid) =>
{

    var category = await dbContext.Categorias.FindAsync(guid);
    if (category is null) return Results.NotFound();
    category.Nombre = categoria.Nombre;
    category.Descripcion = categoria.Descripcion;
    category.Peso = categoria.Peso;
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});


app.MapDelete("/api/tareas/{guid}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid guid) =>
{
    var work = await dbContext.Tareas.FindAsync(guid);
    if (work is null) return Results.NotFound();
    dbContext.Tareas.Remove(work);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});
app.Run();
