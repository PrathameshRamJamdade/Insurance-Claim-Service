using Claim_ServiceAPI.Models.Claims.Lookups;

namespace Claim_ServiceAPI.Repositories.Interfaces;

public interface IClaimLookupRepository
{
    Task<IReadOnlyList<ClaimType>> GetClaimTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<ClaimType?> GetClaimTypeByIdAsync(int claimTypeId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimStatus>> GetClaimStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<ClaimStatus?> GetClaimStatusByIdAsync(int claimStatusId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimPriority>> GetClaimPrioritiesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<ClaimPriority?> GetClaimPriorityByIdAsync(int priorityId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimDocumentType>> GetClaimDocumentTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<ClaimDocumentType?> GetClaimDocumentTypeByIdAsync(int documentTypeId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimActionType>> GetClaimActionTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<ClaimActionType?> GetClaimActionTypeByIdAsync(int actionTypeId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<AssessmentStatus>> GetAssessmentStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<AssessmentStatus?> GetAssessmentStatusByIdAsync(int assessmentStatusId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<SettlementType>> GetSettlementTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<SettlementType?> GetSettlementTypeByIdAsync(int settlementTypeId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<PaymentStatus>> GetPaymentStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<PaymentStatus?> GetPaymentStatusByIdAsync(int paymentStatusId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimVerificationStatus>> GetClaimVerificationStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<ClaimVerificationStatus?> GetClaimVerificationStatusByIdAsync(int verificationStatusId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ClaimPartyType>> GetClaimPartyTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default);

    Task<ClaimPartyType?> GetClaimPartyTypeByIdAsync(int partyTypeId, CancellationToken cancellationToken = default);
}