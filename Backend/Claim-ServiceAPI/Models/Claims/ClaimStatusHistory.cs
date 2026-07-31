using Claim_ServiceAPI.Enums;
using Claim_ServiceAPI.Models.Claims.Lookups;

namespace Claim_ServiceAPI.Models.Claims;

public class ClaimStatusHistory
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

    public Claim? Claim { get; set; }

    public ClaimStatus? PreviousStatus { get; set; }

    public ClaimStatus? CurrentStatus { get; set; }
}