using System;
using System.Xml.Linq;
using Request.API.Entities;

namespace Request.API.Data;

public class SqlServerContextSeed
{
    public static void SeedData(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            Seed(serviceScope.ServiceProvider.GetService<SqlServerContext>());
        }
    }
    private static void Seed(SqlServerContext dbContext)
	{
		if (!dbContext.Estados.Any())
		{
			dbContext.Estados.AddRange(GetEstados());
			dbContext.SaveChanges();
            Console.WriteLine($"Tabla Estado: {typeof(SqlServerContext).Name} seeded.");
		}
	}
	private static IEnumerable<Estado> GetEstados()
	{
		return new List<Estado>
		{
			new()
			{
				Id = 1,
				Nombre = "Estado 1",
				CreatedAt = DateTime.Now,
			}
		};
	}
}

