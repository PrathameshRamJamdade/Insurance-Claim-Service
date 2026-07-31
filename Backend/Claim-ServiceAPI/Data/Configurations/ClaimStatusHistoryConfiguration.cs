using Claim_ServiceAPI.Models.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Claim_ServiceAPI.Data.Configurations;

public class ClaimStatusHistoryConfiguration : IEntityTypeConfiguration<ClaimStatusHistory>
{
    public void Configure(EntityTypeBuilder<ClaimStatusHistory> builder)
    {
        builder.ToTable("ClaimStatusHistory");

        builder.HasKey(entity => entity.ClaimStatusHistoryId);

        builder.Property(entity => entity.ClaimStatusHistoryId)
            .ValueGeneratedOnAdd();

        builder.Property(entity => entity.ChangedAt)
            .HasColumnType("datetimeoffset");

        builder.Property(entity => entity.ReasonCode)
            .HasMaxLength(50);

        builder.Property(entity => entity.Comments)
            .HasMaxLength(1000);

        builder.Property(entity => entity.Source)
            .HasConversion<int?>();

        builder.HasIndex(entity => entity.ClaimId);
        builder.HasIndex(entity => entity.PreviousStatusId);
        builder.HasIndex(entity => entity.CurrentStatusId);
        builder.HasIndex(entity => entity.ChangedByUserId);

        builder.HasOne(entity => entity.PreviousStatus)
            .WithMany()
            .HasForeignKey(entity => entity.PreviousStatusId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(entity => entity.CurrentStatus)
            .WithMany()
            .HasForeignKey(entity => entity.CurrentStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}