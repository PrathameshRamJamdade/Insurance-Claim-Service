using Claim_ServiceAPI.DTOs.Claims;

namespace Claim_ServiceAPI.Services.Interfaces;

public interface IClaimHistoryService
{
    Task<IReadOnlyList<ClaimStatusHistoryDto>> GetStatusHistoryByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimActionHistoryDto>> GetActionHistoryByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<ClaimStatusHistoryDto> CreateStatusHistoryAsync(CreateClaimStatusHistoryDto dto, CancellationToken cancellationToken = default);

    Task<ClaimActionHistoryDto> CreateActionHistoryAsync(CreateClaimActionHistoryDto dto, CancellationToken cancellationToken = default);

    Task<bool> DeleteStatusHistoryAsync(long claimStatusHistoryId, CancellationToken cancellationToken = default);

    Task<bool> DeleteActionHistoryAsync(long claimActionHistoryId, CancellationToken cancellationToken = default);
}