using System;
using Laboratory.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.API.Data.Configuration;

public class LaboratorioServicioConfiguration : IEntityTypeConfiguration<LaboratorioServicio>
{
    public void Configure(EntityTypeBuilder<LaboratorioServicio> builder)
    {
        builder.ToTable("T_LAB_LABORATORIOS_SERVICIOS");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.HasIndex(e => e.DepartamentoId, "IX_LaboratorioServicio_DepartamentoId");
        builder.Property(e => e.DepartamentoId).HasColumnName("departamento_id");

        builder.HasIndex(e => e.ServicioId, "IX_LaboratorioServicio_ServicioId");
        builder.Property(e => e.ServicioId).HasColumnName("servicio_id");

        builder.Property(e => e.Tipo)
            .HasColumnName("tipo");

        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime")
            .HasColumnName("created_at");

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");

        builder.Property(e => e.DeletedAt)
            .HasColumnType("datetime")
            .HasColumnName("deleted_at");
    }
}

