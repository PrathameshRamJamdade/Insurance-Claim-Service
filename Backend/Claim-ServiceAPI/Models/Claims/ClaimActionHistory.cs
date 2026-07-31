using System.Text.Json;
using Claim_ServiceAPI.Models.Claims.Lookups;

namespace Claim_ServiceAPI.Models.Claims;

public class ClaimActionHistory
{
    public long ClaimActionHistoryId { get; set; }

    public long ClaimId { get; set; }

    public int ActionTypeId { get; set; }

    public long ActionByUserId { get; set; }

    public DateTimeOffset ActionAt { get; set; }

    public string? Remarks { get; set; }

    public JsonDocument? OldValuesJson { get; set; }

    public JsonDocument? NewValuesJson { get; set; }

    public string? CorrelationId { get; set; }

    public Claim? Claim { get; set; }

    public ClaimActionType? ActionType { get; set; }
}