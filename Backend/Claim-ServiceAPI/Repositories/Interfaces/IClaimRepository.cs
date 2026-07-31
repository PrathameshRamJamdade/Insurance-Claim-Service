using Claim_ServiceAPI.Models.Claims;

namespace Claim_ServiceAPI.Repositories.Interfaces;

public interface IClaimRepository
{
    Task<IReadOnlyList<Claim>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Claim?> GetByIdAsync(long claimId, bool includeDetails = false, bool asNoTracking = true, CancellationToken cancellationToken = default);

    Task<Claim?> GetByClaimNumberAsync(string claimNumber, bool includeDetails = false, bool asNoTracking = true, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(long claimId, CancellationToken cancellationToken = default);

    Task<bool> ClaimNumberExistsAsync(string claimNumber, long? excludedClaimId = null, CancellationToken cancellationToken = default);

    Task AddAsync(Claim claim, CancellationToken cancellationToken = default);

    void Update(Claim claim);

    void Remove(Claim claim);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}