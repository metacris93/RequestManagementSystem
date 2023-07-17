using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Request.API.Entities;

namespace Request.API.Data;

public class SqlServerContext : DbContext
{
    public DbSet<Estado> Estados { get; set; }
    public DbSet<EstadoSolicitud> EstadoSolicitudes { get; set; }
    public DbSet<Solicitud> Solicitudes { get; set; }

    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

