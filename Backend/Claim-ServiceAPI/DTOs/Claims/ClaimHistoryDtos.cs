using System.ComponentModel.DataAnnotations;
using Claim_ServiceAPI.DTOs.Claims.Lookups;
using Claim_ServiceAPI.Enums;

namespace Claim_ServiceAPI.DTOs.Claims;

public class ClaimStatusHistoryDto
{
    public long ClaimStatusHistoryId { get; set; }

    public long ClaimId { get; set; }

    public int? PreviousStatusId { get; set; }

    public int CurrentStatusId { get; set; }

    public long ChangedByUserId { get; set; }

    public DateTimeOffset ChangedAt { get; set; }

    public string? ReasonCode { get; set; }

    public string? Comments { get; set; }

    public ClaimStatusChangeSource? Source { get; set; }

    public ClaimStatusDto? PreviousStatus { get; set; }

    public ClaimStatusDto? CurrentStatus { get; set; }
}

public class CreateClaimStatusHistoryDto
{
    [Required]
    public long ClaimId { get; set; }

    public int? PreviousStatusId { get; set; }

    [Required]
    public int CurrentStatusId { get; set; }

    [Required]
    public long ChangedByUserId { get; set; }

    [Required]
    public DateTimeOffset ChangedAt { get; set; }

    [StringLength(50)]
    public string? ReasonCode { get; set; }

    [StringLength(1000)]
    public string? Comments { get; set; }

    public ClaimStatusChangeSource? Source { get; set; }
}

public class ClaimActionHistoryDto
{
    public long ClaimActionHistoryId { get; set; }

    public long ClaimId { get; set; }

    public int ActionTypeId { get; set; }

    public long ActionByUserId { get; set; }

    public DateTimeOffset ActionAt { get; set; }

    public string? Remarks { get; set; }

    public string? OldValuesJson { get; set; }

    public string? NewValuesJson { get; set; }

    public string? CorrelationId { get; set; }

    public ClaimActionTypeDto? ActionType { get; set; }
}

public class CreateClaimActionHistoryDto
{
    [Required]
    public long ClaimId { get; set; }

    [Required]
    public int ActionTypeId { get; set; }

    [Required]
    public long ActionByUserId { get; set; }

    [Required]
    public DateTimeOffset ActionAt { get; set; }

    public string? Remarks { get; set; }

    public string? OldValuesJson { get; set; }

    public string? NewValuesJson { get; set; }

    [StringLength(100)]
    public string? CorrelationId { get; set; }
}