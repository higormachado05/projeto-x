using Microsoft.EntityFrameworkCore;
using PJ_API.Infrastructure.Persistence;
using PJ_API.Application.Commands.Authentication.Login;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HEContext")));

// Repositórios
builder.Services.AddScoped<PJ_API.Domain.Repositories.IClientRepository, PJ_API.Infrastructure.Repositories.ClientRepository>();

// Handlers
builder.Services.AddScoped<LoginCommandHandler>();

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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
