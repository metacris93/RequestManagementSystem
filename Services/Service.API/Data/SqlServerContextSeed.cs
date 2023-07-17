using System;
using Service.API.Entities;

namespace Service.API.Data;

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
        if (!dbContext.Departamentos.Any())
        {
            dbContext.Departamentos.AddRange(GetDepartamentos());
            dbContext.SaveChanges();
            Console.WriteLine($"Tabla Estado: {typeof(SqlServerContext).Name} seeded.");
        }
    }
    private static IEnumerable<Departamento> GetDepartamentos()
    {
        return new List<Departamento>
        {
            new()
            {
                Id = 1,
                LaboratorioId = 1,
                MetodologiaId = 1,
                MuestraId = 1,
                ParametroId = 1,
                ServicioId = 1,
                Acreditado = true,
                Muestreo = false,
                TipoAcreditacion = "A",
                CreatedAt = DateTime.Now
            }
        };
    }
}

