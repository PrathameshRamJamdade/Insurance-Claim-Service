using Claim_ServiceAPI.DTOs.Common;

namespace Claim_ServiceAPI.DTOs.Claims.Lookups;

public class ClaimTypeDto : LookupDto
{
}

public class ClaimPriorityDto : LookupDto
{
}

public class ClaimActionTypeDto : LookupDto
{
}

public class AssessmentStatusDto : LookupDto
{
}

public class SettlementTypeDto : LookupDto
{
}

public class PaymentStatusDto : LookupDto
{
}

public class ClaimVerificationStatusDto : LookupDto
{
}

public class ClaimPartyTypeDto : LookupDto
{
}

public class ClaimStatusDto : LookupDto
{
    public int SequenceNo { get; set; }

    public bool IsTerminal { get; set; }
}

public class ClaimDocumentTypeDto : LookupDto
{
    public bool IsMandatory { get; set; }
}