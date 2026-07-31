using Claim_ServiceAPI.Models.Claims;

namespace Claim_ServiceAPI.Repositories.Interfaces;

public interface IClaimDocumentRepository
{
    Task<IReadOnlyList<ClaimDocument>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<ClaimDocument?> GetByIdAsync(long claimDocumentId, bool asNoTracking = true, CancellationToken cancellationToken = default);

    Task AddAsync(ClaimDocument claimDocument, CancellationToken cancellationToken = default);

    void Update(ClaimDocument claimDocument);

    void Remove(ClaimDocument claimDocument);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}