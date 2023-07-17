using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.API.Entities;

namespace Service.API.Data.Configuration;

public class MuestraConfiguration : IEntityTypeConfiguration<Muestra>
{
    public void Configure(EntityTypeBuilder<Muestra> builder)
    {
        builder.ToTable("T_SERV_MUESTRA");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Nombre)
            .HasColumnName("nombre");

        builder.Property(e => e.Descripcion)
            .HasColumnName("descripcion");

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

