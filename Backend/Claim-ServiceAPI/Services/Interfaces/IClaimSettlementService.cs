using Claim_ServiceAPI.DTOs.Claims;

namespace Claim_ServiceAPI.Services.Interfaces;

public interface IClaimSettlementService
{
    Task<IReadOnlyList<ClaimSettlementDto>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<ClaimSettlementDto?> GetByIdAsync(long claimSettlementId, CancellationToken cancellationToken = default);

    Task<ClaimSettlementDto> CreateAsync(CreateClaimSettlementDto dto, CancellationToken cancellationToken = default);

    Task<ClaimSettlementDto?> UpdateAsync(long claimSettlementId, UpdateClaimSettlementDto dto, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(long claimSettlementId, CancellationToken cancellationToken = default);
}