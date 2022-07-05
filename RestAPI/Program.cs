using Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSingleton<Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/api/items/{id}", (context) =>
{
    var id = Convert.ToInt32(context.GetRouteValue("id"));
    var service = context.RequestServices.GetRequiredService<Service>();
    var item = service.GetItem(id);
    return context.Response.WriteAsJsonAsync(item);

});

app.Run();

