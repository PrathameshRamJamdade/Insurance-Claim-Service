using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims.Lookups;

public class ClaimPartyType : LookupEntityBase
{
    public int PartyTypeId { get; set; }

    public ICollection<ClaimParty> Parties { get; set; } = new List<ClaimParty>();
}