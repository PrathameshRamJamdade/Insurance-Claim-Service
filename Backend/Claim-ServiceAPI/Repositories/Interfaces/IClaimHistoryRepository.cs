using Claim_ServiceAPI.Models.Claims;

namespace Claim_ServiceAPI.Repositories.Interfaces;

public interface IClaimHistoryRepository
{
    Task<IReadOnlyList<ClaimStatusHistory>> GetStatusHistoryByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimActionHistory>> GetActionHistoryByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<ClaimStatusHistory?> GetStatusHistoryByIdAsync(long claimStatusHistoryId, bool asNoTracking = true, CancellationToken cancellationToken = default);

    Task<ClaimActionHistory?> GetActionHistoryByIdAsync(long claimActionHistoryId, bool asNoTracking = true, CancellationToken cancellationToken = default);

    Task AddStatusHistoryAsync(ClaimStatusHistory claimStatusHistory, CancellationToken cancellationToken = default);

    Task AddActionHistoryAsync(ClaimActionHistory claimActionHistory, CancellationToken cancellationToken = default);

    void RemoveStatusHistory(ClaimStatusHistory claimStatusHistory);

    void RemoveActionHistory(ClaimActionHistory claimActionHistory);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}