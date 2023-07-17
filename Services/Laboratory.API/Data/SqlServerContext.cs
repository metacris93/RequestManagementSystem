using System;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Laboratory.API.Entities;

namespace Laboratory.API.Data;

public class SqlServerContext : DbContext
{
    public DbSet<Laboratorio> Laboratorios { get; set; }
    public DbSet<LaboratorioServicio> LaboratorioServicios { get; set; }
    public DbSet<LaboratorioUsuario> LaboratorioUsuarios { get; set; }

    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
