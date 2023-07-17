using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Services.Common.Data;

public static class CommonProperty
{
    public static EntityTypeBuilder<BaseEntity> AddKeyProperty(this EntityTypeBuilder<BaseEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");
        return builder;
    }
    public static EntityTypeBuilder<BaseEntity> AddAuditProperty(this EntityTypeBuilder<BaseEntity> builder)
    {
        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime")
            .HasColumnName("created_at");

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");

        builder.Property(e => e.DeletedAt)
            .HasColumnType("datetime")
            .HasColumnName("deleted_at");

        return builder;
    }
}

