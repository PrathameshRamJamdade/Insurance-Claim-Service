using Claim_ServiceAPI.Models.Claims;

namespace Claim_ServiceAPI.Repositories.Interfaces;

public interface IClaimPartyRepository
{
    Task<IReadOnlyList<ClaimParty>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<ClaimParty?> GetByIdAsync(long claimPartyId, bool asNoTracking = true, CancellationToken cancellationToken = default);

    Task AddAsync(ClaimParty claimParty, CancellationToken cancellationToken = default);

    void Update(ClaimParty claimParty);

    void Remove(ClaimParty claimParty);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}