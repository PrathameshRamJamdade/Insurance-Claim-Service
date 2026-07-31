using Claim_ServiceAPI.Models.Claims;

namespace Claim_ServiceAPI.Repositories.Interfaces;

public interface IClaimAssessmentRepository
{
    Task<IReadOnlyList<ClaimAssessment>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<ClaimAssessment?> GetByIdAsync(long claimAssessmentId, bool asNoTracking = true, CancellationToken cancellationToken = default);

    Task AddAsync(ClaimAssessment claimAssessment, CancellationToken cancellationToken = default);

    void Update(ClaimAssessment claimAssessment);

    void Remove(ClaimAssessment claimAssessment);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}