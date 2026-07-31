using Claim_ServiceAPI.DTOs.Claims.Lookups;

namespace Claim_ServiceAPI.Services.Interfaces;

public interface IClaimLookupService
{
    Task<IReadOnlyList<ClaimTypeDto>> GetClaimTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimStatusDto>> GetClaimStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimPriorityDto>> GetClaimPrioritiesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimDocumentTypeDto>> GetClaimDocumentTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimActionTypeDto>> GetClaimActionTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<AssessmentStatusDto>> GetAssessmentStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<SettlementTypeDto>> GetSettlementTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<PaymentStatusDto>> GetPaymentStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimVerificationStatusDto>> GetClaimVerificationStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimPartyTypeDto>> GetClaimPartyTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);
}