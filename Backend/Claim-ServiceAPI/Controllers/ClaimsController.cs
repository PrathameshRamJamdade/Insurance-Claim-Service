using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Services.Interfaces;
using Claim_ServiceAPI.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Claim_ServiceAPI.Controllers;

[Route("api/claims")]
[Authorize(Policy = ClaimServicePolicies.ClaimRead)]
public class ClaimsController : ClaimControllerBase
{
    private readonly IClaimService _claimService;

    public ClaimsController(IClaimService claimService)
    {
        _claimService = claimService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClaimSummaryDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var claims = await _claimService.GetAllAsync(cancellationToken);
        return Ok(claims);
    }

    [HttpGet("{claimId:long}")]
    public async Task<ActionResult<ClaimDetailDto>> GetByIdAsync(long claimId, CancellationToken cancellationToken)
    {
        var claim = await _claimService.GetByIdAsync(claimId, cancellationToken);
        return claim == null ? NotFound() : Ok(claim);
    }

    [HttpGet("by-number/{claimNumber}")]
    public async Task<ActionResult<ClaimDetailDto>> GetByClaimNumberAsync(string claimNumber, CancellationToken cancellationToken)
    {
        var claim = await _claimService.GetByClaimNumberAsync(claimNumber, cancellationToken);
        return claim == null ? NotFound() : Ok(claim);
    }

    [HttpPost]
    [Authorize(Policy = ClaimServicePolicies.ClaimCreate)]
    public async Task<ActionResult<ClaimDetailDto>> CreateAsync([FromBody] CreateClaimDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var claim = await _claimService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetByIdAsync), new { claimId = claim.ClaimId }, claim);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpPut("{claimId:long}")]
    [Authorize(Policy = ClaimServicePolicies.ClaimUpdate)]
    public async Task<ActionResult<ClaimDetailDto>> UpdateAsync(long claimId, [FromBody] UpdateClaimDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var claim = await _claimService.UpdateAsync(claimId, dto, cancellationToken);
            return claim == null ? NotFound() : Ok(claim);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpDelete("{claimId:long}")]
    [Authorize(Policy = ClaimServicePolicies.ClaimUpdate)]
    public async Task<IActionResult> DeleteAsync(long claimId, CancellationToken cancellationToken)
    {
        var deleted = await _claimService.DeleteAsync(claimId, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}