using Microsoft.EntityFrameworkCore;
using EcommerceAPI.Models;
using EcommerceAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
connectionString = StringCipher.SimpleDecryptWithPassword(connectionString, "password12345");
//builder.Services.AddDbContext<EcommerceWebsiteContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<EcommerceAPI_dbContext>(options => options.UseSqlServer(connectionString));
//run in package manager console to get data tables
//Scaffold-DbContext "Data Source=BTHL8LRV2D3;Initial Catalog=EcommerceWebsite;Integrated Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer

//For enabling migration/create migration use prefix --> EntityFrameworkCore\ --> ex) EntityFrameworkCore\update-database -context [CONTEXT]

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS
builder.Services.AddCors(options => options.AddPolicy(name: "FrontendUI",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontendUI");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
