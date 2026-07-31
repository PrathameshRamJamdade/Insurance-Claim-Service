using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims.Lookups;

public class SettlementType : LookupEntityBase
{
    public int SettlementTypeId { get; set; }

    public ICollection<ClaimSettlement> Settlements { get; set; } = new List<ClaimSettlement>();
}