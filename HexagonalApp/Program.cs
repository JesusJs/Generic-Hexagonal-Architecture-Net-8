using AutoMapper;
using HexagonalApp.Application.Mappers;
using HexagonalApp.Application.UseCase;
using HexagonalApp.Domain.ErrorHandling;
using HexagonalApp.Domain.Interfaces.Repository;
using HexagonalApp.Domain.Interfaces.UseCase;
using HexagonalApp.Infrastructure.Context;
using HexagonalApp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IClientsUseCase, ClientsUseCase>();
builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddDbContext<HexagonalAppContext>();
//builder.Services.AddDbContext<HexagonalAppContext>(options =>
//    options.UseSqlServer(builder.Configuration["Database:ConnectionString"]));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
}).CreateMapper());
builder.Services.AddScoped<MappingProfile>();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GlobalExceptionHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<GlobalExceptionHandler>();
app.MapControllers();
app.Run();