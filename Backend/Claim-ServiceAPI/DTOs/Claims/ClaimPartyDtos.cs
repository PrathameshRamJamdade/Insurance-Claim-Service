using System.ComponentModel.DataAnnotations;
using Claim_ServiceAPI.DTOs.Claims.Lookups;
using Claim_ServiceAPI.DTOs.Common;

namespace Claim_ServiceAPI.DTOs.Claims;

public class ClaimPartyDto : AuditableResponseDto
{
    public long ClaimPartyId { get; set; }

    public long ClaimId { get; set; }

    public int PartyTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? Remarks { get; set; }

    public ClaimPartyTypeDto? PartyType { get; set; }
}

public class CreateClaimPartyDto
{
    [Required]
    public long ClaimId { get; set; }

    [Required]
    public int PartyTypeId { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [StringLength(20)]
    public string? ContactNumber { get; set; }

    [StringLength(150)]
    [EmailAddress]
    public string? Email { get; set; }

    [StringLength(150)]
    public string? AddressLine1 { get; set; }

    [StringLength(150)]
    public string? AddressLine2 { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? State { get; set; }

    [StringLength(100)]
    public string? Country { get; set; }

    [StringLength(20)]
    public string? PostalCode { get; set; }

    [StringLength(100)]
    public string? ReferenceNumber { get; set; }

    [StringLength(500)]
    public string? Remarks { get; set; }
}

public class UpdateClaimPartyDto : CreateClaimPartyDto
{
}