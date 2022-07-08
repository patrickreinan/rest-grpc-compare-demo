using Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSingleton<Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/api/items/{id}", (int id, Service service) =>
{
    return service.GetItem(id);

});

app.MapPost("/api/items", (Item item, Service service) =>
{
    return service.PostItem(item);

});

app.Run();

