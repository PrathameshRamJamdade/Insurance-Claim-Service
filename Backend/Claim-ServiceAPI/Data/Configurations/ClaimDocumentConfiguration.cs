using Claim_ServiceAPI.Models.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Claim_ServiceAPI.Data.Configurations;

public class ClaimDocumentConfiguration : IEntityTypeConfiguration<ClaimDocument>
{
    public void Configure(EntityTypeBuilder<ClaimDocument> builder)
    {
        builder.ToTable("ClaimDocument");

        builder.HasKey(entity => entity.ClaimDocumentId);

        builder.Property(entity => entity.ClaimDocumentId)
            .ValueGeneratedOnAdd();

        builder.Property(entity => entity.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(entity => entity.OriginalFileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(entity => entity.FileExtension)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(entity => entity.MimeType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(entity => entity.StoragePath)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(entity => entity.StorageProvider)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(entity => entity.Checksum)
            .HasMaxLength(128);

        builder.Property(entity => entity.UploadedAt)
            .HasColumnType("datetimeoffset");

        builder.Property(entity => entity.VerifiedAt)
            .HasColumnType("datetimeoffset");

        builder.Property(entity => entity.Remarks)
            .HasMaxLength(500);

        builder.HasIndex(entity => entity.ClaimId);
        builder.HasIndex(entity => entity.DocumentTypeId);
        builder.HasIndex(entity => entity.VerificationStatusId);

        builder.HasOne(entity => entity.DocumentType)
            .WithMany(entity => entity.Documents)
            .HasForeignKey(entity => entity.DocumentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.VerificationStatus)
            .WithMany(entity => entity.Documents)
            .HasForeignKey(entity => entity.VerificationStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ConfigureAuditableEntity();
    }
}