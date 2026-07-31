using Claim_ServiceAPI.Models.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Claim_ServiceAPI.Data.Configurations;

public class ClaimAssessmentConfiguration : IEntityTypeConfiguration<ClaimAssessment>
{
    public void Configure(EntityTypeBuilder<ClaimAssessment> builder)
    {
        builder.ToTable("ClaimAssessment");

        builder.HasKey(entity => entity.ClaimAssessmentId);

        builder.Property(entity => entity.ClaimAssessmentId)
            .ValueGeneratedOnAdd();

        builder.Property(entity => entity.AssessmentDate)
            .HasColumnType("datetimeoffset");

        builder.Property(entity => entity.EstimatedLossAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.AssessedAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.RecommendedAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.DepreciationAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.SalvageAmount)
            .HasPrecision(18, 2);

        builder.Property(entity => entity.LiabilityPercentage)
            .HasPrecision(5, 2);

        builder.Property(entity => entity.AssessmentSummary)
            .HasColumnType("nvarchar(max)")
            .IsRequired();

        builder.Property(entity => entity.InternalRemarks)
            .HasColumnType("nvarchar(max)");

        builder.HasIndex(entity => entity.ClaimId);
        builder.HasIndex(entity => entity.AssessmentStatusId);
        builder.HasIndex(entity => entity.AssessorUserId);

        builder.HasOne(entity => entity.AssessmentStatus)
            .WithMany(entity => entity.Assessments)
            .HasForeignKey(entity => entity.AssessmentStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ConfigureAuditableEntity();
    }
}