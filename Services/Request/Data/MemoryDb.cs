using System;
using RequestService.Models;

namespace RequestService.Data;

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
        if (!context.Requests.Any())
        {
            Console.WriteLine("Seeding data");
            context.Requests.AddRange(
                new Request
                {
                    Id = 1,
                    ServicioId = 1,
                    SubCategoriaServicioId = 1,
                    MetodologiaId = 1,
                    MuestraId = 1,
                    Acreditado = true,
                    Muestreo = false,
                    Descripcion = "Descripcion 1",
                    ClienteId = 1,
                    CreatedAt = DateTime.Now,
                    EstadoId = 1,
                    FechaFinalizacion = DateTime.Now.AddDays(1),
                    LaboratorioAsignadoId = 1
                },
                new Request
                {
                    Id = 2,
                    ServicioId = 2,
                    SubCategoriaServicioId = 2,
                    MetodologiaId = 2,
                    MuestraId = 2,
                    Acreditado = false,
                    Muestreo = true,
                    Descripcion = "Descripcion 2",
                    ClienteId = 2,
                    CreatedAt = DateTime.Now,
                    EstadoId = 2,
                    FechaFinalizacion = DateTime.Now.AddDays(1),
                    LaboratorioAsignadoId = 2,
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

