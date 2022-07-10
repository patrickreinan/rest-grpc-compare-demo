using Domain;
using RestAPI.dto;
using RestAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services
    .AddSingleton<Service>()
    .AddSingleton<Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/api/items/{id}", (string id, Service service) =>
{
    return Task.Run(() =>
    {

        var item = service.GetById(id);
        return new GetItemResponse(item.Message);

    });

});

app.MapPost("/api/items", (PostItemRequest request, Service service) =>
{

    return Task.Run(() =>
    {

        var id = service.PostItem(request.Message);
        return new PostItemResponse(id);

    });


});

app.Run();



