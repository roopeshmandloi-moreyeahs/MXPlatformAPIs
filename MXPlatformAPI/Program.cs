using FluentValidation.AspNetCore;
using MXPlatformAPI.Validator;
using MXPlatformAPI.Validator.Interfaces;
using MXPlatformAPI.Validator.Services;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger); //Serilog
builder.Services.AddControllers().AddFluentValidation(); //Fluent Validator
builder.Services.AddTransient<IUserValidation, UserValidation>();
builder.Services.AddTransient<IMemberValidation, MemberValidation>();


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
