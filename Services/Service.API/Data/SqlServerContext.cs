using System;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Service.API.Entities;

namespace Service.API.Data;

public class SqlServerContext : DbContext
{
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Metodologia> Metodologias { get; set; }
    public DbSet<Muestra> Muestras { get; set; }
    public DbSet<ParametroServicio> ParametroServicios { get; set; }
    public DbSet<Servicio> Servicios { get; set; }
    public DbSet<ServicioMetodologia> ServicioMetodologias { get; set; }
    public DbSet<ServicioMuestra> ServicioMuestras { get; set; }

    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

