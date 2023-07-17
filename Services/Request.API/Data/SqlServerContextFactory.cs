using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Request.API.Data;

public class SqlServerContextFactory : IDesignTimeDbContextFactory<SqlServerContext>
{
    private readonly IWebHostEnvironment _env;
    public SqlServerContextFactory(IWebHostEnvironment env)
    {
        _env = env;
    }

    public SqlServerContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqlServerContext>();
        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
        return new SqlServerContext(optionsBuilder.Options);
    }
}

