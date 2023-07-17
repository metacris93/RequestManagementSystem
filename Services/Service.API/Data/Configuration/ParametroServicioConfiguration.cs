using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.API.Entities;

namespace Service.API.Data.Configuration;

public class ParametroServicioConfiguration : IEntityTypeConfiguration<ParametroServicio>
{
    public void Configure(EntityTypeBuilder<ParametroServicio> builder)
    {
        builder.ToTable("T_SERV_PARAMETRO_SERVICIO");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Nombre)
            .HasColumnName("nombre");

        builder.Property(e => e.Descripcion)
            .HasColumnName("descripcion");

        builder.HasIndex(e => e.ServicioId, "IX_ParametroServicio_ServicioId");
        builder.Property(e => e.ServicioId).HasColumnName("servicio_id");

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

