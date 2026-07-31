using System.ComponentModel.DataAnnotations;
using Claim_ServiceAPI.DTOs.Claims.Lookups;
using Claim_ServiceAPI.DTOs.Common;

namespace Claim_ServiceAPI.DTOs.Claims;

public class ClaimSettlementDto : AuditableResponseDto
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

    public SettlementTypeDto? SettlementType { get; set; }

    public PaymentStatusDto? PaymentStatus { get; set; }
}

public class CreateClaimSettlementDto
{
    [Required]
    public long ClaimId { get; set; }

    [Required]
    public int SettlementTypeId { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal ApprovedAmount { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal DeductionsAmount { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99")]
    public decimal NetPayableAmount { get; set; }

    public DateOnly? SettlementDate { get; set; }

    [Required]
    public int PaymentStatusId { get; set; }

    [StringLength(100)]
    public string? PaymentReferenceNumber { get; set; }

    [StringLength(150)]
    public string? PaidToName { get; set; }

    [StringLength(50)]
    public string? PaidToAccountMasked { get; set; }

    [StringLength(1000)]
    public string? Remarks { get; set; }
}

public class UpdateClaimSettlementDto : CreateClaimSettlementDto
{
}