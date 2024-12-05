using DataLayer;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS to allow Angular app to interact with the API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Register other services to the container
builder.Services.AddControllers();

// Register logging for DataSettings
builder.Services.AddSingleton(sp =>
{
    var logger = sp.GetRequiredService<ILogger<DataSettings>>();
    DataSettings.ConfigureLogger(logger); // Ensures the logger is configured before use
    return logger;
});

// Add services for Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS policy for Angular app
app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline for Swagger UI in Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map API controllers
app.MapControllers();

app.Run();
