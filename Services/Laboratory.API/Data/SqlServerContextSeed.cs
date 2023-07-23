using System;
using Laboratory.API.Entities;

namespace Laboratory.API.Data;

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
        if (!dbContext.Laboratorios.Any())
        {
            dbContext.Laboratorios.AddRange(GetLaboratorios());
            dbContext.SaveChanges();
            Console.WriteLine($"Tabla Laboratorio: {typeof(SqlServerContext).Name} seeded.");
        }
    }
    private static IEnumerable<Laboratorio> GetLaboratorios()
    {
        return new List<Laboratorio>
        {
            new()
            {
                Id = 1,
                Nombre = "Laboratorio 1",
                Descripcion = "Laboratorio Descripcion 1",
                CreatedAt = DateTime.Now,
                Imagen = "https://picsum.photos/id/237/200/300"
            }
        };
    }
}

