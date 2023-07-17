using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.API.Entities;

namespace Service.API.Data.Configuration;

public class ServicioMuestraConfiguration : IEntityTypeConfiguration<ServicioMuestra>
{
    public void Configure(EntityTypeBuilder<ServicioMuestra> builder)
    {
        builder.ToTable("T_SERV_SERVICIO_MUESTRAS");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.HasIndex(e => e.ServicioId, "IX_ServicioMuestra_ServicioId");
        builder.Property(e => e.ServicioId).HasColumnName("servicio_id");

        builder.HasIndex(e => e.MuestraId, "IX_ServicioMuestra_MuestraId");
        builder.Property(e => e.MuestraId).HasColumnName("muestra_id");

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

