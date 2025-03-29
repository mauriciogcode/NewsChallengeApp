using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsApi.Infrastructure.Persistence;
using Serilog;
using MediatR;
using NewsApi.Application.Handlers;


var builder = WebApplication.CreateBuilder(args);

// Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// PostgreSQL
builder.Services.AddDbContext<NewsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CreateNewsCommandHandler).Assembly);
});

var app = builder.Build();

// Seed
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<NewsDbContext>();
    context.Database.Migrate();
    SeedData.Initialize(context);
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

//try
//{
//    using var scope = app.Services.CreateScope();
//    var dbContext = scope.ServiceProvider.GetRequiredService<NewsDbContext>();
//    // Intenta una consulta simple
//    var canConnect = dbContext.Database.CanConnect();
//    Log.Information($"Database connection test: {(canConnect ? "Successful" : "Failed")}");
//}
//catch (Exception ex)
//{
//    Log.Error(ex, "Error testing database connection");
//}

app.Run();
