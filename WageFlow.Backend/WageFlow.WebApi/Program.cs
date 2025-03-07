using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using WageFlow.Application.src.Common.Mapping;
using WageFlow.Persistence.src.Data;
using WageFlow.Application.src.Common.Dependencies;
using WageFlow.Application.src.Interfaces;
using WageFlow.WebApi.src.Middleware;
using Serilog;
using Serilog.Events;
using TelegramSink;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IWageFlowDbContext).Assembly));
});

builder.Services.AddSerilog();
builder.Services.AddAplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.TeleSink(
                telegramApiKey: "*key",
                telegramChatId: "*id")
                .CreateLogger();

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<WageFlowDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint("swagger/v1/swagger.json", "WageFlow.Backend");
});
app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
