using back.Middleware;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseCors("AllowAll");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();