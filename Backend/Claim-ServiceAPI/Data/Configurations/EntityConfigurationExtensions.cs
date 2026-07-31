using Claim_ServiceAPI.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Claim_ServiceAPI.Data.Configurations;

internal static class EntityConfigurationExtensions
{
    public static void ConfigureAuditableEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : AuditableEntityBase
    {
        builder.Property(entity => entity.CreatedAt)
            .HasColumnType("datetimeoffset");

        builder.Property(entity => entity.CreatedBy);

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnType("datetimeoffset");

        builder.Property(entity => entity.UpdatedBy);

        builder.Property(entity => entity.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(entity => entity.DeletedAt)
            .HasColumnType("datetimeoffset");

        builder.Property(entity => entity.VersionNo)
            .HasDefaultValue(1L);

        builder.Property(entity => entity.CorrelationId)
            .HasMaxLength(100);
    }

    public static void ConfigureLookupEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : LookupEntityBase
    {
        builder.Property(entity => entity.Code)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(entity => entity.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(entity => entity.Description)
            .HasMaxLength(300);

        builder.Property(entity => entity.IsActive)
            .HasDefaultValue(true);
    }
}