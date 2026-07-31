using Claim_ServiceAPI.Models.Claims.Lookups;
using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims;

public class ClaimSettlement : AuditableEntityBase
{
    public long ClaimSettlementId { get; set; }

    public long ClaimId { get; set; }

    public int SettlementTypeId { get; set; }

    public decimal ApprovedAmount { get; set; }

    public decimal DeductionsAmount { get; set; }

    public decimal NetPayableAmount { get; set; }

    public DateOnly? SettlementDate { get; set; }

    public int PaymentStatusId { get; set; }

    public string? PaymentReferenceNumber { get; set; }

    public string? PaidToName { get; set; }

    public string? PaidToAccountMasked { get; set; }

    public string? Remarks { get; set; }

    public Claim? Claim { get; set; }

    public SettlementType? SettlementType { get; set; }

    public PaymentStatus? PaymentStatus { get; set; }
}