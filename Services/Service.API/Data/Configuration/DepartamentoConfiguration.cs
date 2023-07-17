using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Service.API.Entities;

namespace Service.API.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("T_SERV_INFO_SERV_DEPARTAMENTO");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.HasIndex(e => e.ServicioId, "IX_Departamento_ServicioId");
        builder.Property(e => e.ServicioId).HasColumnName("servicio_id");

        builder.HasIndex(e => e.MetodologiaId, "IX_Departamento_MetodologiaId");
        builder.Property(e => e.MetodologiaId).HasColumnName("metodologia_id");

        builder.HasIndex(e => e.MuestraId, "IX_Departamento_MuestraId");
        builder.Property(e => e.MuestraId).HasColumnName("muestra_id");

        builder.HasIndex(e => e.LaboratorioId, "IX_Departamento_LaboratorioId");
        builder.Property(e => e.LaboratorioId).HasColumnName("laboratorio_id");

        builder.HasIndex(e => e.ParametroId, "IX_Departamento_ParametroId");
        builder.Property(e => e.ParametroId).HasColumnName("parametro_id");

        builder.Property(e => e.Acreditado)
            .HasColumnName("acreditado");

        builder.Property(e => e.Muestreo)
            .HasColumnName("muestreo");

        builder.Property(e => e.Muestreo)
            .HasMaxLength(2)
            .HasColumnName("tipo_acreditacion");

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

