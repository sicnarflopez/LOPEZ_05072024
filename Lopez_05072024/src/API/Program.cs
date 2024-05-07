using API;
using API.Authentication;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddWebAPIServices();

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File($"Logs/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}/FileProcessing.txt", rollingInterval: RollingInterval.Hour)
                .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyAuthMiddleware>();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.Run();
