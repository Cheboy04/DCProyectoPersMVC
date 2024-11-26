using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DC_ProyectoPers_API.Data;
using DC_ProyectoPers_API.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DC_ProyectoPers_APIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DC_ProyectoPers_APIContext") ?? throw new InvalidOperationException("Connection string 'DC_ProyectoPers_APIContext' not found.")));

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

app.MapDCBebidaEndpoints();

app.Run();
