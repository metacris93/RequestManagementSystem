using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.API.Entities;

namespace Service.API.Data.Configuration;

public class ServicioMetodologiaConfiguration : IEntityTypeConfiguration<ServicioMetodologia>
{
    public void Configure(EntityTypeBuilder<ServicioMetodologia> builder)
    {
        builder.ToTable("T_SERV_SERVICIO_METODOLOGIA");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.HasIndex(e => e.ServicioId, "IX_ServicioMetodologia_ServicioId");
        builder.Property(e => e.ServicioId).HasColumnName("servicio_id");

        builder.HasIndex(e => e.MetodologiaId, "IX_ServicioMetodologia_MuestraId");
        builder.Property(e => e.MetodologiaId).HasColumnName("metodologia_id");

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

