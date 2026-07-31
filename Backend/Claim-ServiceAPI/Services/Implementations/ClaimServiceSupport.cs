using Claim_ServiceAPI.Models.Common;
using Claim_ServiceAPI.Repositories.Interfaces;

namespace Claim_ServiceAPI.Services.Implementations;

internal static class ClaimServiceSupport
{
    public static void ApplyCreationAudit(AuditableEntityBase entity)
    {
        var now = DateTimeOffset.UtcNow;
        entity.CreatedAt = now;
        entity.UpdatedAt = null;
        entity.DeletedAt = null;
        entity.IsDeleted = false;
        entity.VersionNo = entity.VersionNo <= 0 ? 1 : entity.VersionNo;
    }

    public static void ApplyUpdateAudit(AuditableEntityBase entity)
    {
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        entity.VersionNo = entity.VersionNo <= 0 ? 1 : entity.VersionNo + 1;
    }

    public static void ApplySoftDelete(AuditableEntityBase entity)
    {
        entity.IsDeleted = true;
        entity.DeletedAt = DateTimeOffset.UtcNow;
        entity.UpdatedAt = entity.DeletedAt;
        entity.VersionNo = entity.VersionNo <= 0 ? 1 : entity.VersionNo + 1;
    }

    public static async Task EnsureClaimExistsAsync(IClaimRepository claimRepository, long claimId, CancellationToken cancellationToken)
    {
        if (!await claimRepository.ExistsAsync(claimId, cancellationToken))
        {
            throw new InvalidOperationException($"Claim with id '{claimId}' was not found.");
        }
    }
}