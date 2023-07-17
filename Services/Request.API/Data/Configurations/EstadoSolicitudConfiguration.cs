using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Request.API.Entities;

namespace Request.API.Data.Configurations;

public class EstadoSolicitudConfiguration : IEntityTypeConfiguration<EstadoSolicitud>
{
    public void Configure(EntityTypeBuilder<EstadoSolicitud> builder)
    {
        builder.ToTable("T_SOL_ESTADOS_SOLICITUD");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.HasIndex(e => e.EstadoId, "IX_EstadoSolicitud_EstadoId");
        builder.Property(e => e.EstadoId).HasColumnName("estado_id");

        builder.HasIndex(e => e.SolicitudId, "IX_EstadoSolicitud_SolicitudId");
        builder.Property(e => e.SolicitudId).HasColumnName("solicitud_id");

        builder.HasIndex(e => e.LaboratorioId, "IX_EstadoSolicitud_LaboratorioId");
        builder.Property(e => e.LaboratorioId).HasColumnName("laboratorio_id");

        builder.HasIndex(e => e.UsuarioSilabId, "IX_EstadoSolicitud_UsuarioSilabId");
        builder.Property(e => e.UsuarioSilabId).HasColumnName("usuario_silab_id");

        builder.HasIndex(e => e.UsuarioDepartamentoId, "IX_EstadoSolicitud_UsuarioDepartamentoId");
        builder.Property(e => e.UsuarioDepartamentoId).HasColumnName("usuario_departamento_id");

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

