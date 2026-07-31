using Claim_ServiceAPI.Models.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Claim_ServiceAPI.Data.Configurations;

public class ClaimActionHistoryConfiguration : IEntityTypeConfiguration<ClaimActionHistory>
{
    public void Configure(EntityTypeBuilder<ClaimActionHistory> builder)
    {
        builder.ToTable("ClaimActionHistory");

        builder.HasKey(entity => entity.ClaimActionHistoryId);

        builder.Property(entity => entity.ClaimActionHistoryId)
            .ValueGeneratedOnAdd();

        builder.Property(entity => entity.ActionAt)
            .HasColumnType("datetimeoffset");

        builder.Property(entity => entity.Remarks)
            .HasColumnType("nvarchar(max)");

        builder.Property(entity => entity.OldValuesJson)
            .HasSqlServerJsonConversion();

        builder.Property(entity => entity.NewValuesJson)
            .HasSqlServerJsonConversion();

        builder.Property(entity => entity.CorrelationId)
            .HasMaxLength(100);

        builder.HasIndex(entity => entity.ClaimId);
        builder.HasIndex(entity => entity.ActionTypeId);
        builder.HasIndex(entity => entity.ActionByUserId);

        builder.HasOne(entity => entity.ActionType)
            .WithMany(entity => entity.ActionHistories)
            .HasForeignKey(entity => entity.ActionTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}