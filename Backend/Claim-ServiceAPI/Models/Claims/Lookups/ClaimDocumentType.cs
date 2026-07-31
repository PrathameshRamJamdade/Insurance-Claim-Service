using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims.Lookups;

public class ClaimDocumentType : LookupEntityBase
{
    public int DocumentTypeId { get; set; }

    public bool IsMandatory { get; set; }

    public ICollection<ClaimDocument> Documents { get; set; } = new List<ClaimDocument>();
}