using Claim_ServiceAPI.Models.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Claim_ServiceAPI.Data.Configurations;

public class ClaimPartyConfiguration : IEntityTypeConfiguration<ClaimParty>
{
    public void Configure(EntityTypeBuilder<ClaimParty> builder)
    {
        builder.ToTable("ClaimParty");

        builder.HasKey(entity => entity.ClaimPartyId);

        builder.Property(entity => entity.ClaimPartyId)
            .ValueGeneratedOnAdd();

        builder.Property(entity => entity.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(entity => entity.ContactNumber)
            .HasMaxLength(20);

        builder.Property(entity => entity.Email)
            .HasMaxLength(150);

        builder.Property(entity => entity.AddressLine1)
            .HasMaxLength(150);

        builder.Property(entity => entity.AddressLine2)
            .HasMaxLength(150);

        builder.Property(entity => entity.City)
            .HasMaxLength(100);

        builder.Property(entity => entity.State)
            .HasMaxLength(100);

        builder.Property(entity => entity.Country)
            .HasMaxLength(100);

        builder.Property(entity => entity.PostalCode)
            .HasMaxLength(20);

        builder.Property(entity => entity.ReferenceNumber)
            .HasMaxLength(100);

        builder.Property(entity => entity.Remarks)
            .HasMaxLength(500);

        builder.HasIndex(entity => entity.ClaimId);
        builder.HasIndex(entity => entity.PartyTypeId);

        builder.HasOne(entity => entity.PartyType)
            .WithMany(entity => entity.Parties)
            .HasForeignKey(entity => entity.PartyTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ConfigureAuditableEntity();
    }
}