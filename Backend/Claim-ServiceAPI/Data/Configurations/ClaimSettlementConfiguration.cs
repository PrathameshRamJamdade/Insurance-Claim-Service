using Claim_ServiceAPI.Models.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Claim_ServiceAPI.Data.Configurations;

public class ClaimSettlementConfiguration : IEntityTypeConfiguration<ClaimSettlement>
{
    public void Configure(EntityTypeBuilder<ClaimSettlement> builder)
    {
        builder.ToTable("ClaimSettlement");

        builder.HasKey(entity => entity.ClaimSettlementId);

        builder.Property(entity => entity.ClaimSettlementId)
            .ValueGeneratedOnAdd();

        builder.Property(entity => entity.ApprovedAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.DeductionsAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.NetPayableAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.SettlementDate)
            .HasColumnType("date");

        builder.Property(entity => entity.PaymentReferenceNumber)
            .HasMaxLength(100);

        builder.Property(entity => entity.PaidToName)
            .HasMaxLength(150);

        builder.Property(entity => entity.PaidToAccountMasked)
            .HasMaxLength(50);

        builder.Property(entity => entity.Remarks)
            .HasMaxLength(1000);

        builder.HasIndex(entity => entity.ClaimId);
        builder.HasIndex(entity => entity.SettlementTypeId);
        builder.HasIndex(entity => entity.PaymentStatusId);

        builder.HasOne(entity => entity.SettlementType)
            .WithMany(entity => entity.Settlements)
            .HasForeignKey(entity => entity.SettlementTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.PaymentStatus)
            .WithMany(entity => entity.Settlements)
            .HasForeignKey(entity => entity.PaymentStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ConfigureAuditableEntity();
    }
}