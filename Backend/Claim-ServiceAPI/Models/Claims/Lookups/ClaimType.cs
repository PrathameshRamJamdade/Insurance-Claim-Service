using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims.Lookups;

public class ClaimType : LookupEntityBase
{
    public int ClaimTypeId { get; set; }

    public ICollection<Claim> Claims { get; set; } = new List<Claim>();
}