namespace Claim_ServiceAPI.Enums;

public enum ClaimStatusChangeSource
{
    Manual = 1,
    System = 2,
    Api = 3,
    BatchJob = 4,
    Integration = 5
}