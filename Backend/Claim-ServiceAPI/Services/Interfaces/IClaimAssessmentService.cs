using Claim_ServiceAPI.DTOs.Claims;

namespace Claim_ServiceAPI.Services.Interfaces;

public interface IClaimAssessmentService
{
    Task<IReadOnlyList<ClaimAssessmentDto>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<ClaimAssessmentDto?> GetByIdAsync(long claimAssessmentId, CancellationToken cancellationToken = default);

    Task<ClaimAssessmentDto> CreateAsync(CreateClaimAssessmentDto dto, CancellationToken cancellationToken = default);

    Task<ClaimAssessmentDto?> UpdateAsync(long claimAssessmentId, UpdateClaimAssessmentDto dto, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(long claimAssessmentId, CancellationToken cancellationToken = default);
}