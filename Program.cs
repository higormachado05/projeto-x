using Swashbuckle.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PJ_API.Domain.Repositories.IClientRepository, PJ_API.Infrastructure.Repositories.ClientRepository>();
// Repositórios
builder.Services.AddScoped<PJ_API.Domain.Repositories.IClientRepository, PJ_API.Infrastructure.Repositories.ClientRepository>();

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
