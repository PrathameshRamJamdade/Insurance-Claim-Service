using System.ComponentModel.DataAnnotations;
using Claim_ServiceAPI.DTOs.Claims.Lookups;
using Claim_ServiceAPI.DTOs.Common;

namespace Claim_ServiceAPI.DTOs.Claims;

public class ClaimSummaryDto
{
    public long ClaimId { get; set; }

    public string ClaimNumber { get; set; } = string.Empty;

    public long PolicyId { get; set; }

    public long CustomerId { get; set; }

    public int ClaimTypeId { get; set; }

    public string ClaimTypeName { get; set; } = string.Empty;

    public int ClaimStatusId { get; set; }

    public string ClaimStatusName { get; set; } = string.Empty;

    public int PriorityId { get; set; }

    public string PriorityName { get; set; } = string.Empty;

    public DateOnly IncidentDate { get; set; }

    public DateTimeOffset ReportedAt { get; set; }

    public decimal ClaimAmount { get; set; }

    public decimal ApprovedAmount { get; set; }

    public decimal SettledAmount { get; set; }

    public long? AssignedToUserId { get; set; }
}

public class ClaimDetailDto : AuditableResponseDto
{
    public long ClaimId { get; set; }

    public long PolicyId { get; set; }

    public long CustomerId { get; set; }

    public string ClaimNumber { get; set; } = string.Empty;

    public int ClaimTypeId { get; set; }

    public int ClaimStatusId { get; set; }

    public DateOnly IncidentDate { get; set; }

    public TimeOnly? IncidentTime { get; set; }

    public DateTimeOffset ReportedAt { get; set; }

    public DateOnly? IntimationDate { get; set; }

    public decimal ClaimAmount { get; set; }

    public decimal ApprovedAmount { get; set; }

    public decimal SettledAmount { get; set; }

    public decimal DeductionAmount { get; set; }

    public string CurrencyCode { get; set; } = string.Empty;

    public string CauseOfLoss { get; set; } = string.Empty;

    public string LossDescription { get; set; } = string.Empty;

    public string? IncidentLocation { get; set; }

    public int PriorityId { get; set; }

    public long? AssignedToUserId { get; set; }

    public decimal? FraudRiskScore { get; set; }

    public string? RejectionReason { get; set; }

    public string? ClosureReason { get; set; }

    public DateTimeOffset? ClosedAt { get; set; }

    public ClaimTypeDto? ClaimType { get; set; }

    public ClaimStatusDto? ClaimStatus { get; set; }

    public ClaimPriorityDto? Priority { get; set; }

    public ICollection<ClaimDocumentDto> Documents { get; set; } = new List<ClaimDocumentDto>();

    public ICollection<ClaimAssessmentDto> Assessments { get; set; } = new List<ClaimAssessmentDto>();

    public ICollection<ClaimStatusHistoryDto> StatusHistory { get; set; } = new List<ClaimStatusHistoryDto>();

    public ICollection<ClaimActionHistoryDto> ActionHistory { get; set; } = new List<ClaimActionHistoryDto>();

    public ICollection<ClaimSettlementDto> Settlements { get; set; } = new List<ClaimSettlementDto>();

    public ICollection<ClaimPartyDto> Parties { get; set; } = new List<ClaimPartyDto>();
}

public class CreateClaimDto
{
    [Required]
    public long PolicyId { get; set; }

    [Required]
    public long CustomerId { get; set; }

    [Required]
    [StringLength(50)]
    public string ClaimNumber { get; set; } = string.Empty;

    [Required]
    public int ClaimTypeId { get; set; }

    [Required]
    public int ClaimStatusId { get; set; }

    [Required]
    public DateOnly IncidentDate { get; set; }

    public TimeOnly? IncidentTime { get; set; }

    [Required]
    public DateTimeOffset ReportedAt { get; set; }

    public DateOnly? IntimationDate { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal ClaimAmount { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal ApprovedAmount { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal SettledAmount { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal DeductionAmount { get; set; }

    [Required]
    [StringLength(3, MinimumLength = 3)]
    public string CurrencyCode { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string CauseOfLoss { get; set; } = string.Empty;

    [Required]
    public string LossDescription { get; set; } = string.Empty;

    [StringLength(300)]
    public string? IncidentLocation { get; set; }

    [Required]
    public int PriorityId { get; set; }

    public long? AssignedToUserId { get; set; }

    [Range(typeof(decimal), "0", "999.99")]
    public decimal? FraudRiskScore { get; set; }

    public string? RejectionReason { get; set; }

    [StringLength(200)]
    public string? ClosureReason { get; set; }

    public DateTimeOffset? ClosedAt { get; set; }
}

public class UpdateClaimDto : CreateClaimDto
{
}