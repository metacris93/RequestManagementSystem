using Laboratory.API;
using Laboratory.API.Data;
using Services.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabase(builder.Configuration, builder.Environment);
builder.Services.RegisterMapsterConfiguration();
builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddApiVersion();
builder.Services.AddSwaggerConfiguration();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var section = builder.Configuration.GetSection("ApiSettings");
builder.Services.AddJwtBearerAuthentication(section);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureSwaggerUI();
    SqlServerContextSeed.SeedData(app);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

