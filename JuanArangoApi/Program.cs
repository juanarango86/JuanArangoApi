using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JuanArangoApi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<JuanArangoApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JuanArangoApiContext") ?? throw new InvalidOperationException("Connection string 'JuanArangoApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SeedDb>();//inyeccion de dependencia para todo el proyecto
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seedDb = services.GetRequiredService<SeedDb>();
    await seedDb.SeedAsync();
}

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
