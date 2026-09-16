using Claim_ServiceAPI.Models.Claims.Lookups;
using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims;

public class Claim : AuditableEntityBase
{
    public long ClaimId { get; set; }

    public string PolicyId { get; set; } = string.Empty;

    public string CustomerId { get; set; } = string.Empty;

    public Guid CustomerIdentityId { get; set; }

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

    public ClaimType? ClaimType { get; set; }

    public ClaimStatus? ClaimStatus { get; set; }

    public ClaimPriority? Priority { get; set; }

    public ICollection<ClaimDocument> Documents { get; set; } = new List<ClaimDocument>();

    public ICollection<ClaimAssessment> Assessments { get; set; } = new List<ClaimAssessment>();

    public ICollection<ClaimStatusHistory> StatusHistory { get; set; } = new List<ClaimStatusHistory>();

    public ICollection<ClaimActionHistory> ActionHistory { get; set; } = new List<ClaimActionHistory>();

    public ICollection<ClaimSettlement> Settlements { get; set; } = new List<ClaimSettlement>();

    public ICollection<ClaimParty> Parties { get; set; } = new List<ClaimParty>();
}