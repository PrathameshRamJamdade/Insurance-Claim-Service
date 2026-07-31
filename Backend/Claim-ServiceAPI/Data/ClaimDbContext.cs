using Claim_ServiceAPI.Data.Configurations;
using Claim_ServiceAPI.Models.Claims;
using Claim_ServiceAPI.Models.Claims.Lookups;
using Microsoft.EntityFrameworkCore;

namespace Claim_ServiceAPI.Data;

public class ClaimDbContext : DbContext
{
    public ClaimDbContext(DbContextOptions<ClaimDbContext> options)
        : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateOnly>()
            .HaveColumnType("date");

        configurationBuilder.Properties<DateOnly?>()
            .HaveColumnType("date");

        configurationBuilder.Properties<TimeOnly>()
            .HaveColumnType("time");

        configurationBuilder.Properties<TimeOnly?>()
            .HaveColumnType("time");

        configurationBuilder.Properties<DateTimeOffset>()
            .HaveColumnType("datetimeoffset");

        configurationBuilder.Properties<DateTimeOffset?>()
            .HaveColumnType("datetimeoffset");
    }

    public DbSet<Claim> Claims => Set<Claim>();

    public DbSet<ClaimDocument> ClaimDocuments => Set<ClaimDocument>();

    public DbSet<ClaimAssessment> ClaimAssessments => Set<ClaimAssessment>();

    public DbSet<ClaimStatusHistory> ClaimStatusHistories => Set<ClaimStatusHistory>();

    public DbSet<ClaimActionHistory> ClaimActionHistories => Set<ClaimActionHistory>();

    public DbSet<ClaimSettlement> ClaimSettlements => Set<ClaimSettlement>();

    public DbSet<ClaimParty> ClaimParties => Set<ClaimParty>();

    public DbSet<ClaimType> ClaimTypes => Set<ClaimType>();

    public DbSet<ClaimStatus> ClaimStatuses => Set<ClaimStatus>();

    public DbSet<ClaimPriority> ClaimPriorities => Set<ClaimPriority>();

    public DbSet<ClaimDocumentType> ClaimDocumentTypes => Set<ClaimDocumentType>();

    public DbSet<ClaimActionType> ClaimActionTypes => Set<ClaimActionType>();

    public DbSet<AssessmentStatus> AssessmentStatuses => Set<AssessmentStatus>();

    public DbSet<SettlementType> SettlementTypes => Set<SettlementType>();

    public DbSet<PaymentStatus> PaymentStatuses => Set<PaymentStatus>();

    public DbSet<ClaimVerificationStatus> ClaimVerificationStatuses => Set<ClaimVerificationStatus>();

    public DbSet<ClaimPartyType> ClaimPartyTypes => Set<ClaimPartyType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClaimDbContext).Assembly);
    }
}