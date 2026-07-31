using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims.Lookups;

public class ClaimActionType : LookupEntityBase
{
    public int ActionTypeId { get; set; }

    public ICollection<ClaimActionHistory> ActionHistories { get; set; } = new List<ClaimActionHistory>();
}