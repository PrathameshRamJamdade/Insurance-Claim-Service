using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims.Lookups;

public class PaymentStatus : LookupEntityBase
{
    public int PaymentStatusId { get; set; }

    public ICollection<ClaimSettlement> Settlements { get; set; } = new List<ClaimSettlement>();
}