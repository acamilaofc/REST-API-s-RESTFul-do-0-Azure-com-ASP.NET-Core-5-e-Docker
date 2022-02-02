using Microsoft.EntityFrameworkCore;
using RESTWithWebAPI.Implementations;
using RESTWithWebAPI.Models.Context;
using RESTWithWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApiVersioning();

builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

var connection = builder.Configuration["SQLServerConnection:SQLServerConnectionString"];
builder.Services.AddDbContext<SQLServerContext>(options => options.UseSqlServer(connection));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
