using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims.Lookups;

public class ClaimStatus : LookupEntityBase
{
    public int ClaimStatusId { get; set; }

    public int SequenceNo { get; set; }

    public bool IsTerminal { get; set; }

    public ICollection<Claim> Claims { get; set; } = new List<Claim>();
}