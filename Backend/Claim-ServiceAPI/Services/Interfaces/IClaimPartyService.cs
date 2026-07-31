using Claim_ServiceAPI.DTOs.Claims;

namespace Claim_ServiceAPI.Services.Interfaces;

public interface IClaimPartyService
{
    Task<IReadOnlyList<ClaimPartyDto>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<ClaimPartyDto?> GetByIdAsync(long claimPartyId, CancellationToken cancellationToken = default);

    Task<ClaimPartyDto> CreateAsync(CreateClaimPartyDto dto, CancellationToken cancellationToken = default);

    Task<ClaimPartyDto?> UpdateAsync(long claimPartyId, UpdateClaimPartyDto dto, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(long claimPartyId, CancellationToken cancellationToken = default);
}