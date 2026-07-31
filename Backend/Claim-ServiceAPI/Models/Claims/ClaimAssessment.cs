using Claim_ServiceAPI.Models.Claims.Lookups;
using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims;

public class ClaimAssessment : AuditableEntityBase
{
    public long ClaimAssessmentId { get; set; }

    public long ClaimId { get; set; }

    public long AssessorUserId { get; set; }

    public DateTimeOffset AssessmentDate { get; set; }

    public decimal EstimatedLossAmount { get; set; }

    public decimal AssessedAmount { get; set; }

    public decimal RecommendedAmount { get; set; }

    public decimal DepreciationAmount { get; set; }

    public decimal SalvageAmount { get; set; }

    public decimal? LiabilityPercentage { get; set; }

    public string AssessmentSummary { get; set; } = string.Empty;

    public string? InternalRemarks { get; set; }

    public int AssessmentStatusId { get; set; }

    public Claim? Claim { get; set; }

    public AssessmentStatus? AssessmentStatus { get; set; }
}