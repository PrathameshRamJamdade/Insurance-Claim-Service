using System.ComponentModel.DataAnnotations;
using Claim_ServiceAPI.DTOs.Claims.Lookups;
using Claim_ServiceAPI.DTOs.Common;

namespace Claim_ServiceAPI.DTOs.Claims;

public class ClaimAssessmentDto : AuditableResponseDto
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

    public AssessmentStatusDto? AssessmentStatus { get; set; }
}

public class CreateClaimAssessmentDto
{
    [Required]
    public long ClaimId { get; set; }

    [Required]
    public long AssessorUserId { get; set; }

    [Required]
    public DateTimeOffset AssessmentDate { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal EstimatedLossAmount { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal AssessedAmount { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal RecommendedAmount { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal DepreciationAmount { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal SalvageAmount { get; set; }

    [Range(typeof(decimal), "0", "100.00")]
    public decimal? LiabilityPercentage { get; set; }

    [Required]
    public string AssessmentSummary { get; set; } = string.Empty;

    public string? InternalRemarks { get; set; }

    [Required]
    public int AssessmentStatusId { get; set; }
}

public class UpdateClaimAssessmentDto : CreateClaimAssessmentDto
{
}