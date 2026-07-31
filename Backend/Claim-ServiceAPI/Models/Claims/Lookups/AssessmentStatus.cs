using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims.Lookups;

public class AssessmentStatus : LookupEntityBase
{
    public int AssessmentStatusId { get; set; }

    public ICollection<ClaimAssessment> Assessments { get; set; } = new List<ClaimAssessment>();
}