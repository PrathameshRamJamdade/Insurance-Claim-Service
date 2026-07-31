using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims.Lookups;

public class ClaimPriority : LookupEntityBase
{
    public int PriorityId { get; set; }

    public ICollection<Claim> Claims { get; set; } = new List<Claim>();
}