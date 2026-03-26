
using Microsoft.EntityFrameworkCore;
using PJ_API.Infrastructure.Persistence;
using PJ_API.Application.Commands.Authentication.Login;
using Application.Commands.User.Create;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS to allow frontend calls during development
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HEContext")));

// Repositórios
builder.Services.AddScoped<PJ_API.Domain.Repositories.IClientRepository, PJ_API.Infrastructure.Repositories.ClientRepository>();

// Handlers

builder.Services.AddScoped<LoginCommandHandler>();
builder.Services.AddScoped<CreateUserCommandHandler>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowLocalhost4200");
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var retries = 10;
    while (retries > 0)
    {
        try
        {
            db.Database.Migrate();
            break;
        }
        catch
        {
            retries--;
            if (retries == 0) throw;
            Thread.Sleep(3000);
        }
    }
}

app.Run();
