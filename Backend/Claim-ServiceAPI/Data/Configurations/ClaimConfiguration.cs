using Claim_ServiceAPI.Models.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Claim_ServiceAPI.Data.Configurations;

public class ClaimConfiguration : IEntityTypeConfiguration<Claim>
{
    public void Configure(EntityTypeBuilder<Claim> builder)
    {
        builder.ToTable("Claim");

        builder.HasKey(entity => entity.ClaimId);

        builder.Property(entity => entity.ClaimId)
            .ValueGeneratedOnAdd();

        builder.Property(entity => entity.ClaimNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(entity => entity.CustomerIdentityId)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.HasIndex(entity => entity.ClaimNumber)
            .IsUnique();

        builder.Property(entity => entity.IncidentDate)
            .HasColumnType("date");

        builder.Property(entity => entity.IncidentTime)
            .HasColumnType("time");

        builder.Property(entity => entity.ReportedAt)
            .HasColumnType("datetimeoffset");

        builder.Property(entity => entity.IntimationDate)
            .HasColumnType("date");

        builder.Property(entity => entity.ClaimAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.ApprovedAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.SettledAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.DeductionAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.CurrencyCode)
            .HasColumnType("char(3)")
            .IsRequired();

        builder.Property(entity => entity.CauseOfLoss)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(entity => entity.LossDescription)
            .HasColumnType("nvarchar(max)")
            .IsRequired();

        builder.Property(entity => entity.IncidentLocation)
            .HasMaxLength(300);

        builder.Property(entity => entity.FraudRiskScore)
            .HasPrecision(5, 2);

        builder.Property(entity => entity.RejectionReason)
            .HasColumnType("nvarchar(max)");

        builder.Property(entity => entity.ClosureReason)
            .HasMaxLength(200);

        builder.Property(entity => entity.ClosedAt)
            .HasColumnType("datetimeoffset");

        builder.HasIndex(entity => entity.PolicyId);
        builder.HasIndex(entity => entity.CustomerId);
    builder.HasIndex(entity => entity.CustomerIdentityId);
        builder.HasIndex(entity => entity.ClaimStatusId);
        builder.HasIndex(entity => entity.ClaimTypeId);
        builder.HasIndex(entity => entity.PriorityId);
        builder.HasIndex(entity => entity.AssignedToUserId);

        builder.HasOne(entity => entity.ClaimType)
            .WithMany(entity => entity.Claims)
            .HasForeignKey(entity => entity.ClaimTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.ClaimStatus)
            .WithMany(entity => entity.Claims)
            .HasForeignKey(entity => entity.ClaimStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.Priority)
            .WithMany(entity => entity.Claims)
            .HasForeignKey(entity => entity.PriorityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(entity => entity.Documents)
            .WithOne(entity => entity.Claim)
            .HasForeignKey(entity => entity.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(entity => entity.Assessments)
            .WithOne(entity => entity.Claim)
            .HasForeignKey(entity => entity.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(entity => entity.StatusHistory)
            .WithOne(entity => entity.Claim)
            .HasForeignKey(entity => entity.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(entity => entity.ActionHistory)
            .WithOne(entity => entity.Claim)
            .HasForeignKey(entity => entity.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(entity => entity.Settlements)
            .WithOne(entity => entity.Claim)
            .HasForeignKey(entity => entity.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(entity => entity.Parties)
            .WithOne(entity => entity.Claim)
            .HasForeignKey(entity => entity.ClaimId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ConfigureAuditableEntity();
    }
}