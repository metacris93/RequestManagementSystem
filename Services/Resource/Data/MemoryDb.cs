using System;
using ResourceService.Models;

namespace ResourceService.Data;

public static class MemoryDb
{
    public static void MemoryPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }
    private static void SeedData(AppDbContext context)
    {
        if (!context.Departments.Any())
        {
            Console.WriteLine("Seeding data");
            context.Departments.AddRange(
                new Department
                {
                    Id = 1,
                    DepartamentoId = 1,
                    MetodologiaId = 1,
                    MuestraId = 1,
                    SubcategoriaId = 1,
                    Acreditado = false,
                    Muestreo = false,
                    TipoAcreditacion = "ACREDITACION A",
                },
                new Department
                {
                    Id = 2,
                    DepartamentoId = 2,
                    MetodologiaId = 2,
                    MuestraId = 2,
                    SubcategoriaId = 2,
                    Acreditado = true,
                    Muestreo = true,
                    TipoAcreditacion = "ACREDITACION B",
                }
            );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("We already have data");
        }
    }
}

