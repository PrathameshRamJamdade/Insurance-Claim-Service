using Claim_ServiceAPI.Models.Claims.Lookups;
using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims;

public class ClaimParty : AuditableEntityBase
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

    public Claim? Claim { get; set; }

    public ClaimPartyType? PartyType { get; set; }
}