using Claim_ServiceAPI.DTOs.Claims.Lookups;
using Claim_ServiceAPI.Services.Interfaces;
using Claim_ServiceAPI.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Claim_ServiceAPI.Controllers;

[Route("api/claim-lookups")]
[Authorize(Policy = ClaimServicePolicies.ClaimLookupRead)]
public class ClaimLookupsController : ClaimControllerBase
{
    private readonly IClaimLookupService _claimLookupService;

    public ClaimLookupsController(IClaimLookupService claimLookupService)
    {
        _claimLookupService = claimLookupService;
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ClaimTypeDto>>> GetClaimTypesAsync([FromQuery] bool activeOnly = true, CancellationToken cancellationToken = default)
    {
        return Ok(await _claimLookupService.GetClaimTypesAsync(activeOnly, cancellationToken));
    }

    [HttpGet("statuses")]
    public async Task<ActionResult<IReadOnlyList<ClaimStatusDto>>> GetClaimStatusesAsync([FromQuery] bool activeOnly = true, CancellationToken cancellationToken = default)
    {
        return Ok(await _claimLookupService.GetClaimStatusesAsync(activeOnly, cancellationToken));
    }

    [HttpGet("priorities")]
    public async Task<ActionResult<IReadOnlyList<ClaimPriorityDto>>> GetClaimPrioritiesAsync([FromQuery] bool activeOnly = true, CancellationToken cancellationToken = default)
    {
        return Ok(await _claimLookupService.GetClaimPrioritiesAsync(activeOnly, cancellationToken));
    }

    [HttpGet("document-types")]
    public async Task<ActionResult<IReadOnlyList<ClaimDocumentTypeDto>>> GetClaimDocumentTypesAsync([FromQuery] bool activeOnly = true, CancellationToken cancellationToken = default)
    {
        return Ok(await _claimLookupService.GetClaimDocumentTypesAsync(activeOnly, cancellationToken));
    }

    [HttpGet("action-types")]
    public async Task<ActionResult<IReadOnlyList<ClaimActionTypeDto>>> GetClaimActionTypesAsync([FromQuery] bool activeOnly = true, CancellationToken cancellationToken = default)
    {
        return Ok(await _claimLookupService.GetClaimActionTypesAsync(activeOnly, cancellationToken));
    }

    [HttpGet("assessment-statuses")]
    public async Task<ActionResult<IReadOnlyList<AssessmentStatusDto>>> GetAssessmentStatusesAsync([FromQuery] bool activeOnly = true, CancellationToken cancellationToken = default)
    {
        return Ok(await _claimLookupService.GetAssessmentStatusesAsync(activeOnly, cancellationToken));
    }

    [HttpGet("settlement-types")]
    public async Task<ActionResult<IReadOnlyList<SettlementTypeDto>>> GetSettlementTypesAsync([FromQuery] bool activeOnly = true, CancellationToken cancellationToken = default)
    {
        return Ok(await _claimLookupService.GetSettlementTypesAsync(activeOnly, cancellationToken));
    }

    [HttpGet("payment-statuses")]
    public async Task<ActionResult<IReadOnlyList<PaymentStatusDto>>> GetPaymentStatusesAsync([FromQuery] bool activeOnly = true, CancellationToken cancellationToken = default)
    {
        return Ok(await _claimLookupService.GetPaymentStatusesAsync(activeOnly, cancellationToken));
    }

    [HttpGet("verification-statuses")]
    public async Task<ActionResult<IReadOnlyList<ClaimVerificationStatusDto>>> GetClaimVerificationStatusesAsync([FromQuery] bool activeOnly = true, CancellationToken cancellationToken = default)
    {
        return Ok(await _claimLookupService.GetClaimVerificationStatusesAsync(activeOnly, cancellationToken));
    }

    [HttpGet("party-types")]
    public async Task<ActionResult<IReadOnlyList<ClaimPartyTypeDto>>> GetClaimPartyTypesAsync([FromQuery] bool activeOnly = true, CancellationToken cancellationToken = default)
    {
        return Ok(await _claimLookupService.GetClaimPartyTypesAsync(activeOnly, cancellationToken));
    }
}