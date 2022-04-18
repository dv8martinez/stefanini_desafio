using Microsoft.EntityFrameworkCore;
using Stefanini.Desafio.Domain.Interfaces.Services;
using Stefanini.Desafio.Infra.Context;
using Stefanini.Desafio.Service.City;
using Stefanini.Desafio.Service.Person;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICityService, Citieservice>();
builder.Services.AddTransient<IPersonService, PersonService>();

builder.Services.AddDbContext<StefaniniContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
  var dataContext = scope.ServiceProvider.GetRequiredService<StefaniniContext>();
  dataContext.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
