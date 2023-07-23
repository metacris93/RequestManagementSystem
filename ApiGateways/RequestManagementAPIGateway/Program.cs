﻿using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using RequestManagementAPIGateway;
using Services.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();
// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddServices();
builder.Services.AddApiVersion();
builder.Services.AddSwaggerConfiguration();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var section = builder.Configuration.GetSection("ApiSettings");
builder.Services.AddJwtBearerAuthentication(section);

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();

app.Run();

