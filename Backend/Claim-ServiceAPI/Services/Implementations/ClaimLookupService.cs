using Claim_ServiceAPI.DTOs.Claims.Lookups;
using Claim_ServiceAPI.Mappers;
using Claim_ServiceAPI.Repositories.Interfaces;
using Claim_ServiceAPI.Services.Interfaces;

namespace Claim_ServiceAPI.Services.Implementations;

public class ClaimLookupService : IClaimLookupService
{
    private readonly IClaimLookupRepository _claimLookupRepository;

    public ClaimLookupService(IClaimLookupRepository claimLookupRepository)
    {
        _claimLookupRepository = claimLookupRepository;
    }

    public async Task<IReadOnlyList<ClaimTypeDto>> GetClaimTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => (await _claimLookupRepository.GetClaimTypesAsync(activeOnly, cancellationToken)).Select(entity => entity.ToDto()).ToList();

    public async Task<IReadOnlyList<ClaimStatusDto>> GetClaimStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => (await _claimLookupRepository.GetClaimStatusesAsync(activeOnly, cancellationToken)).Select(entity => entity.ToDto()).ToList();

    public async Task<IReadOnlyList<ClaimPriorityDto>> GetClaimPrioritiesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => (await _claimLookupRepository.GetClaimPrioritiesAsync(activeOnly, cancellationToken)).Select(entity => entity.ToDto()).ToList();

    public async Task<IReadOnlyList<ClaimDocumentTypeDto>> GetClaimDocumentTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => (await _claimLookupRepository.GetClaimDocumentTypesAsync(activeOnly, cancellationToken)).Select(entity => entity.ToDto()).ToList();

    public async Task<IReadOnlyList<ClaimActionTypeDto>> GetClaimActionTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => (await _claimLookupRepository.GetClaimActionTypesAsync(activeOnly, cancellationToken)).Select(entity => entity.ToDto()).ToList();

    public async Task<IReadOnlyList<AssessmentStatusDto>> GetAssessmentStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => (await _claimLookupRepository.GetAssessmentStatusesAsync(activeOnly, cancellationToken)).Select(entity => entity.ToDto()).ToList();

    public async Task<IReadOnlyList<SettlementTypeDto>> GetSettlementTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => (await _claimLookupRepository.GetSettlementTypesAsync(activeOnly, cancellationToken)).Select(entity => entity.ToDto()).ToList();

    public async Task<IReadOnlyList<PaymentStatusDto>> GetPaymentStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => (await _claimLookupRepository.GetPaymentStatusesAsync(activeOnly, cancellationToken)).Select(entity => entity.ToDto()).ToList();

    public async Task<IReadOnlyList<ClaimVerificationStatusDto>> GetClaimVerificationStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => (await _claimLookupRepository.GetClaimVerificationStatusesAsync(activeOnly, cancellationToken)).Select(entity => entity.ToDto()).ToList();

    public async Task<IReadOnlyList<ClaimPartyTypeDto>> GetClaimPartyTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => (await _claimLookupRepository.GetClaimPartyTypesAsync(activeOnly, cancellationToken)).Select(entity => entity.ToDto()).ToList();
}