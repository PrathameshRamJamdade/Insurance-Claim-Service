using Claim_ServiceAPI.DTOs.Claims;

namespace Claim_ServiceAPI.Services.Interfaces;

public interface IClaimDocumentService
{
    Task<IReadOnlyList<ClaimDocumentDto>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default);

    Task<ClaimDocumentDto?> GetByIdAsync(long claimDocumentId, CancellationToken cancellationToken = default);

    Task<ClaimDocumentDto> CreateAsync(CreateClaimDocumentDto dto, CancellationToken cancellationToken = default);

    Task<ClaimDocumentDto?> UpdateAsync(long claimDocumentId, UpdateClaimDocumentDto dto, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(long claimDocumentId, CancellationToken cancellationToken = default);
}