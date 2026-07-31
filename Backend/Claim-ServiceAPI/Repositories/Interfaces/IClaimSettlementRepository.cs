using Claim_ServiceAPI.Models.Claims;

namespace Claim_ServiceAPI.Repositories.Interfaces;

public interface IClaimSettlementRepository
{
    Task<IReadOnlyList<ClaimSettlement>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<ClaimSettlement?> GetByIdAsync(long claimSettlementId, bool asNoTracking = true, CancellationToken cancellationToken = default);

    Task AddAsync(ClaimSettlement claimSettlement, CancellationToken cancellationToken = default);

    void Update(ClaimSettlement claimSettlement);

    void Remove(ClaimSettlement claimSettlement);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}