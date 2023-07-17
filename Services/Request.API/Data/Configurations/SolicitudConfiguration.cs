using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.API.Entities;

namespace Request.API.Data.Configurations;

public class SolicitudConfiguration : IEntityTypeConfiguration<Solicitud>
{
    public void Configure(EntityTypeBuilder<Solicitud> builder)
    {
        builder.ToTable("T_SOL_SOLICITUD");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.HasIndex(e => e.ServicioId, "IX_Solicitud_ServicioId");
        builder.Property(e => e.ServicioId).HasColumnName("servicio_id");

        builder.HasIndex(e => e.MetodologiaId, "IX_Solicitud_MetodologiaId");
        builder.Property(e => e.MetodologiaId).HasColumnName("metodologia_id");

        builder.HasIndex(e => e.ParametroId, "IX_Solicitud_ParametroId");
        builder.Property(e => e.ParametroId).HasColumnName("parametro_id");

        builder.HasIndex(e => e.MuestraId, "IX_Solicitud_MuestraId");
        builder.Property(e => e.MuestraId).HasColumnName("muestra_id");

        builder.HasIndex(e => e.ClienteId, "IX_Solicitud_ClienteId");
        builder.Property(e => e.ClienteId).HasColumnName("cliente_id");

        builder.HasIndex(e => e.LaboratorioAsignadoId, "IX_Solicitud_LaboratorioAsignadoId");
        builder.Property(e => e.LaboratorioAsignadoId).HasColumnName("laboratorio_asignado_id");

        builder.Property(e => e.Acreditado).HasColumnName("acreditado");
        builder.Property(e => e.Muestreo).HasColumnName("muestreo");
        builder.Property(e => e.Descripcion).HasColumnName("descripcion");
        builder.Property(e => e.Estado).HasColumnName("estado");
        builder.Property(e => e.FechaFinalizacion)
            .HasColumnType("datetime")
            .HasColumnName("fecha_finalizacion");

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

