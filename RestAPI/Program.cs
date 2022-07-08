using Domain;
using RestAPI.dto;
using RestAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSingleton<Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/api/items/{id}", (int id, Service service) =>
{
    return Task.Run(() =>
    {
        var item = service.GetItem(id);

        //dto criada para ter um objeto intermediário assim como acontece no grpc
        return new GetItemRequest
        (
            item.Id,
            item.Message,
            item.Field1,
            item.Field2,
            item.Field3,
            item.Field4,
            item.Field5
        );
    });

});

app.MapPost("/api/items", (PostItemRequest item, Service service) =>
{

    return Task.Run(() => {

    //dto criada para ter um objeto intermediário assim como acontece no grpc
        var id = service.PostItem(
                new Item(
                    item.Id,
                    item.Message,
                    item.Field1,
                    item.Field2,
                    item.Field3,
                    item.Field4,
                    item.Field5)
                );


        return new PostItemResponse(id);

    });
   

});

app.Run();



