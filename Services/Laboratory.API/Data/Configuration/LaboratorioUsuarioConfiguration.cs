using System;
using Laboratory.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laboratory.API.Data.Configuration;

public class LaboratorioUsuarioConfiguration : IEntityTypeConfiguration<LaboratorioUsuario>
{
    public void Configure(EntityTypeBuilder<LaboratorioUsuario> builder)
    {
        builder.ToTable("T_LAB_USUARIO_LABORATORIOS");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.HasIndex(e => e.LaboratorioId, "IX_LaboratorioServicio_LaboratorioId");
        builder.Property(e => e.LaboratorioId).HasColumnName("laboratorio_id");

        builder.HasIndex(e => e.UsuarioId, "IX_LaboratorioServicio_UsuarioId");
        builder.Property(e => e.UsuarioId).HasColumnName("usuario_id");

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

