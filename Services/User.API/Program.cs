using Microsoft.AspNetCore.Identity;
using Services.Common;
using User.API;
using User.API.Data;
using User.API.Entities;
using User.API.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabase(builder.Configuration, builder.Environment);
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
builder.Services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<SqlServerContext>()
    .AddDefaultTokenProviders();
builder.Services.RegisterMapsterConfiguration();
builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddApiVersion();
builder.Services.AddSwaggerConfiguration();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var section = builder.Configuration.GetSection("ApiSettings:JwtOptions");
builder.Services.AddJwtBearerAuthentication(section);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.ConfigureSwaggerUI();
    SqlServerContextSeed.SeedData(app);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

