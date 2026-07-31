using Claim_ServiceAPI.DTOs.Claims;

namespace Claim_ServiceAPI.Services.Interfaces;

public interface IClaimService
{
    Task<IReadOnlyList<ClaimSummaryDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<ClaimDetailDto?> GetByIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<ClaimDetailDto?> GetByClaimNumberAsync(string claimNumber, CancellationToken cancellationToken = default);

    Task<ClaimDetailDto> CreateAsync(CreateClaimDto dto, CancellationToken cancellationToken = default);

    Task<ClaimDetailDto?> UpdateAsync(long claimId, UpdateClaimDto dto, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(long claimId, CancellationToken cancellationToken = default);
}