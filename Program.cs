using Microsoft.EntityFrameworkCore;
using PJ_API.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HEContext")));

// Repositórios
builder.Services.AddScoped<PJ_API.Domain.Repositories.IClientRepository, PJ_API.Infrastructure.Repositories.ClientRepository>();

var app = builder.Build();

// Aplicar migrations automaticamente com retry
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    
    var retryCount = 0;
    var maxRetries = 10;
    
    while (retryCount < maxRetries)
    {
        try
        {
            logger.LogInformation("Tentando aplicar migrations... (tentativa {RetryCount}/{MaxRetries})", retryCount + 1, maxRetries);
            dbContext.Database.Migrate();
            logger.LogInformation("Migrations aplicadas com sucesso!");
            break;
        }
        catch (Exception ex)
        {
            retryCount++;
            if (retryCount >= maxRetries)
            {
                logger.LogError(ex, "Falha ao aplicar migrations após {MaxRetries} tentativas", maxRetries);
                throw;
            }
            logger.LogWarning("Falha ao aplicar migrations. Aguardando 5 segundos antes de tentar novamente...");
            Thread.Sleep(5000);
        }
    }
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
