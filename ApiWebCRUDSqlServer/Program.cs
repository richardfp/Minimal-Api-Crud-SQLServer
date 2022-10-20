using ApiWebCRUDSqlServer.Models;
using ApiWebCRUDSqlServer.Repositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICarRepository, CarRepository>();

var app = builder.Build();

app.MapGet("/v1/car", ([FromServices] ICarRepository repository) =>
{
    return repository.GetCars();
});

app.MapPost("/v1/car", ([FromServices] ICarRepository repository, CarModel car) =>
{
    var result = repository.InsertCar(car);

    return (result ? Results.Ok($"Carro {car.Modelo} inserido com sucesso")
    :
    Results.BadRequest("Não foi possivel inserir o carro"));
});

app.MapPut("/v1/car", ([FromServices] ICarRepository repository, int id, string cor) =>
{
    var result = repository.UpdateCarCor(cor , id);

    return (result ? Results.Ok($"Cor alterada com sucesso") 
    :
    Results.BadRequest("Não foi possivel alterar a cor do carro"));

});

app.MapDelete("/v1/car", ([FromServices] ICarRepository repository, int id) =>
{
    var result = repository.DeleteCar(id);

    return (result ? Results.Ok($"Carro Deletado com sucesso")
    :
    Results.BadRequest("Não foi possivel deletar o carro"));

});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();