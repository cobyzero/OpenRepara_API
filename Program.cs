using Microsoft.EntityFrameworkCore;
using OpenRepara_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<OpenReparaContext>((option) =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("db"));
});

var app = builder.Build();
  
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
