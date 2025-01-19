using InventoryManagementBackend.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using dotenv.net;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

//load env variables
DotEnv.Load();

//retrieve connection string components from environment variables
var pgHost = Environment.GetEnvironmentVariable("PGHOST");
var pgDatabase = Environment.GetEnvironmentVariable("PGDATABASE");
var pgUser = Environment.GetEnvironmentVariable("PGUSER");
var pgPassword = Environment.GetEnvironmentVariable("PGPASSWORD");

//configure database context
var connectionString = $"Host={pgHost};Database={pgDatabase};Username={pgUser};Password={pgPassword}";

builder.Services.AddDbContext<ApplicationDbContext>(options=>{
    options.UseNpgsql(connectionString);
});

// Add services to the container.

builder.Services.AddControllers();

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
