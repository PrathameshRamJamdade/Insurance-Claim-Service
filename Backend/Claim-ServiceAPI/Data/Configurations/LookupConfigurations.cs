using Claim_ServiceAPI.Models.Claims.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Claim_ServiceAPI.Data.Configurations;

public class ClaimTypeConfiguration : IEntityTypeConfiguration<ClaimType>
{
    public void Configure(EntityTypeBuilder<ClaimType> builder)
    {
        builder.ToTable("ClaimType");
        builder.HasKey(entity => entity.ClaimTypeId);
        builder.Property(entity => entity.ClaimTypeId).ValueGeneratedNever();
        builder.HasIndex(entity => entity.Code).IsUnique();
        builder.ConfigureLookupEntity();
    }
}

public class ClaimStatusConfiguration : IEntityTypeConfiguration<ClaimStatus>
{
    public void Configure(EntityTypeBuilder<ClaimStatus> builder)
    {
        builder.ToTable("ClaimStatus");
        builder.HasKey(entity => entity.ClaimStatusId);
        builder.Property(entity => entity.ClaimStatusId).ValueGeneratedNever();
        builder.Property(entity => entity.SequenceNo).IsRequired();
        builder.Property(entity => entity.IsTerminal).HasDefaultValue(false);
        builder.HasIndex(entity => entity.Code).IsUnique();
        builder.ConfigureLookupEntity();
    }
}

public class ClaimPriorityConfiguration : IEntityTypeConfiguration<ClaimPriority>
{
    public void Configure(EntityTypeBuilder<ClaimPriority> builder)
    {
        builder.ToTable("ClaimPriority");
        builder.HasKey(entity => entity.PriorityId);
        builder.Property(entity => entity.PriorityId).ValueGeneratedNever();
        builder.HasIndex(entity => entity.Code).IsUnique();
        builder.ConfigureLookupEntity();
    }
}

public class ClaimDocumentTypeConfiguration : IEntityTypeConfiguration<ClaimDocumentType>
{
    public void Configure(EntityTypeBuilder<ClaimDocumentType> builder)
    {
        builder.ToTable("ClaimDocumentType");
        builder.HasKey(entity => entity.DocumentTypeId);
        builder.Property(entity => entity.DocumentTypeId).ValueGeneratedNever();
        builder.Property(entity => entity.IsMandatory).HasDefaultValue(false);
        builder.HasIndex(entity => entity.Code).IsUnique();
        builder.ConfigureLookupEntity();
    }
}

public class ClaimActionTypeConfiguration : IEntityTypeConfiguration<ClaimActionType>
{
    public void Configure(EntityTypeBuilder<ClaimActionType> builder)
    {
        builder.ToTable("ClaimActionType");
        builder.HasKey(entity => entity.ActionTypeId);
        builder.Property(entity => entity.ActionTypeId).ValueGeneratedNever();
        builder.HasIndex(entity => entity.Code).IsUnique();
        builder.ConfigureLookupEntity();
    }
}

public class AssessmentStatusConfiguration : IEntityTypeConfiguration<AssessmentStatus>
{
    public void Configure(EntityTypeBuilder<AssessmentStatus> builder)
    {
        builder.ToTable("AssessmentStatus");
        builder.HasKey(entity => entity.AssessmentStatusId);
        builder.Property(entity => entity.AssessmentStatusId).ValueGeneratedNever();
        builder.HasIndex(entity => entity.Code).IsUnique();
        builder.ConfigureLookupEntity();
    }
}

public class SettlementTypeConfiguration : IEntityTypeConfiguration<SettlementType>
{
    public void Configure(EntityTypeBuilder<SettlementType> builder)
    {
        builder.ToTable("SettlementType");
        builder.HasKey(entity => entity.SettlementTypeId);
        builder.Property(entity => entity.SettlementTypeId).ValueGeneratedNever();
        builder.HasIndex(entity => entity.Code).IsUnique();
        builder.ConfigureLookupEntity();
    }
}

public class PaymentStatusConfiguration : IEntityTypeConfiguration<PaymentStatus>
{
    public void Configure(EntityTypeBuilder<PaymentStatus> builder)
    {
        builder.ToTable("PaymentStatus");
        builder.HasKey(entity => entity.PaymentStatusId);
        builder.Property(entity => entity.PaymentStatusId).ValueGeneratedNever();
        builder.HasIndex(entity => entity.Code).IsUnique();
        builder.ConfigureLookupEntity();
    }
}

public class ClaimVerificationStatusConfiguration : IEntityTypeConfiguration<ClaimVerificationStatus>
{
    public void Configure(EntityTypeBuilder<ClaimVerificationStatus> builder)
    {
        builder.ToTable("ClaimVerificationStatus");
        builder.HasKey(entity => entity.VerificationStatusId);
        builder.Property(entity => entity.VerificationStatusId).ValueGeneratedNever();
        builder.HasIndex(entity => entity.Code).IsUnique();
        builder.ConfigureLookupEntity();
    }
}

public class ClaimPartyTypeConfiguration : IEntityTypeConfiguration<ClaimPartyType>
{
    public void Configure(EntityTypeBuilder<ClaimPartyType> builder)
    {
        builder.ToTable("ClaimPartyType");
        builder.HasKey(entity => entity.PartyTypeId);
        builder.Property(entity => entity.PartyTypeId).ValueGeneratedNever();
        builder.HasIndex(entity => entity.Code).IsUnique();
        builder.ConfigureLookupEntity();
    }
}