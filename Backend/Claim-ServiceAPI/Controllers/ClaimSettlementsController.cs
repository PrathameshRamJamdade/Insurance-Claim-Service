using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Services.Interfaces;
using Claim_ServiceAPI.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Claim_ServiceAPI.Controllers;

[Route("api/claims/{claimId:long}/settlements")]
[Authorize(Policy = ClaimServicePolicies.ClaimRead)]
public class ClaimSettlementsController : ClaimControllerBase
{
    private readonly IClaimSettlementService _claimSettlementService;

    public ClaimSettlementsController(IClaimSettlementService claimSettlementService)
    {
        _claimSettlementService = claimSettlementService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClaimSettlementDto>>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken)
    {
        var settlements = await _claimSettlementService.GetByClaimIdAsync(claimId, cancellationToken);
        return Ok(settlements);
    }

    [HttpGet("{claimSettlementId:long}")]
    public async Task<ActionResult<ClaimSettlementDto>> GetByIdAsync(long claimId, long claimSettlementId, CancellationToken cancellationToken)
    {
        var settlement = await _claimSettlementService.GetByIdAsync(claimSettlementId, cancellationToken);
        return settlement == null || settlement.ClaimId != claimId ? NotFound() : Ok(settlement);
    }

    [HttpPost]
    [Authorize(Policy = ClaimServicePolicies.ClaimSettlementManage)]
    public async Task<ActionResult<ClaimSettlementDto>> CreateAsync(long claimId, [FromBody] CreateClaimSettlementDto dto, CancellationToken cancellationToken)
    {
        if (dto.ClaimId != claimId)
        {
            return BadRequest("Route claimId and payload ClaimId must match.");
        }

        try
        {
            var settlement = await _claimSettlementService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetByIdAsync), new { claimId, claimSettlementId = settlement.ClaimSettlementId }, settlement);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpPut("{claimSettlementId:long}")]
    [Authorize(Policy = ClaimServicePolicies.ClaimSettlementManage)]
    public async Task<ActionResult<ClaimSettlementDto>> UpdateAsync(long claimId, long claimSettlementId, [FromBody] UpdateClaimSettlementDto dto, CancellationToken cancellationToken)
    {
        if (dto.ClaimId != claimId)
        {
            return BadRequest("Route claimId and payload ClaimId must match.");
        }

        try
        {
            var settlement = await _claimSettlementService.UpdateAsync(claimSettlementId, dto, cancellationToken);
            return settlement == null || settlement.ClaimId != claimId ? NotFound() : Ok(settlement);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpDelete("{claimSettlementId:long}")]
    [Authorize(Policy = ClaimServicePolicies.ClaimSettlementManage)]
    public async Task<IActionResult> DeleteAsync(long claimId, long claimSettlementId, CancellationToken cancellationToken)
    {
        var settlement = await _claimSettlementService.GetByIdAsync(claimSettlementId, cancellationToken);
        if (settlement == null || settlement.ClaimId != claimId)
        {
            return NotFound();
        }

        var deleted = await _claimSettlementService.DeleteAsync(claimSettlementId, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}