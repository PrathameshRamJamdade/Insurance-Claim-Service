using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims.Lookups;

public class ClaimVerificationStatus : LookupEntityBase
{
    public int VerificationStatusId { get; set; }

    public ICollection<ClaimDocument> Documents { get; set; } = new List<ClaimDocument>();
}