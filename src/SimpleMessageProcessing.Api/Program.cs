using Microsoft.EntityFrameworkCore;
using SimpleMessageProcessing.Api.Databases;
using SimpleMessageProcessing.Api;
using SimpleMessageProcessing.Library.Abstractions;
using SimpleMessageProcessing.Api.Services;
using SimpleMessageProcessing.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(SimpleMessageProcessing.Api.Profiles.SimpleMessageProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors(builder.Configuration);

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
string DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}SimpleMessegeDb.db";
builder.Services.AddDbContextPool<SimpleMessegeDbContext>(options => { options.UseSqlite($"Data Source={DbPath}"); });

builder.Services.ConfigureSystemConfiguration(builder.Configuration);
// Custom Service
builder.Services.AddScoped<IParseService, ParseService>();
builder.Services.AddScoped<INormalizeService, NormalizeService>();
builder.Services.AddScoped<ISimpleMessageRepositories, SimpleMessageRepositories>();
builder.Services.AddScoped<ISimpleMessageProcess, SimpleMessageProcess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(Constants.Cors.AllowedOriginsPolicy);

// Add the EndpointRoutingMiddleware
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
