using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Services.Interfaces;
using Claim_ServiceAPI.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Claim_ServiceAPI.Controllers;

[Route("api/claims/{claimId:long}/history")]
[Authorize(Policy = ClaimServicePolicies.ClaimHistoryManage)]
public class ClaimHistoriesController : ClaimControllerBase
{
    private readonly IClaimHistoryService _claimHistoryService;

    public ClaimHistoriesController(IClaimHistoryService claimHistoryService)
    {
        _claimHistoryService = claimHistoryService;
    }

    [HttpGet("status")]
    public async Task<ActionResult<IReadOnlyList<ClaimStatusHistoryDto>>> GetStatusHistoryAsync(long claimId, CancellationToken cancellationToken)
    {
        var history = await _claimHistoryService.GetStatusHistoryByClaimIdAsync(claimId, cancellationToken);
        return Ok(history);
    }

    [HttpGet("actions")]
    public async Task<ActionResult<IReadOnlyList<ClaimActionHistoryDto>>> GetActionHistoryAsync(long claimId, CancellationToken cancellationToken)
    {
        var history = await _claimHistoryService.GetActionHistoryByClaimIdAsync(claimId, cancellationToken);
        return Ok(history);
    }

    [HttpPost("status")]
    public async Task<ActionResult<ClaimStatusHistoryDto>> CreateStatusHistoryAsync(long claimId, [FromBody] CreateClaimStatusHistoryDto dto, CancellationToken cancellationToken)
    {
        if (dto.ClaimId != claimId)
        {
            return BadRequest("Route claimId and payload ClaimId must match.");
        }

        try
        {
            var history = await _claimHistoryService.CreateStatusHistoryAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetStatusHistoryAsync), new { claimId }, history);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpPost("actions")]
    public async Task<ActionResult<ClaimActionHistoryDto>> CreateActionHistoryAsync(long claimId, [FromBody] CreateClaimActionHistoryDto dto, CancellationToken cancellationToken)
    {
        if (dto.ClaimId != claimId)
        {
            return BadRequest("Route claimId and payload ClaimId must match.");
        }

        try
        {
            var history = await _claimHistoryService.CreateActionHistoryAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetActionHistoryAsync), new { claimId }, history);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpDelete("status/{claimStatusHistoryId:long}")]
    public async Task<IActionResult> DeleteStatusHistoryAsync(long claimId, long claimStatusHistoryId, CancellationToken cancellationToken)
    {
        var history = await _claimHistoryService.GetStatusHistoryByClaimIdAsync(claimId, cancellationToken);
        if (history.All(item => item.ClaimStatusHistoryId != claimStatusHistoryId))
        {
            return NotFound();
        }

        var deleted = await _claimHistoryService.DeleteStatusHistoryAsync(claimStatusHistoryId, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpDelete("actions/{claimActionHistoryId:long}")]
    public async Task<IActionResult> DeleteActionHistoryAsync(long claimId, long claimActionHistoryId, CancellationToken cancellationToken)
    {
        var history = await _claimHistoryService.GetActionHistoryByClaimIdAsync(claimId, cancellationToken);
        if (history.All(item => item.ClaimActionHistoryId != claimActionHistoryId))
        {
            return NotFound();
        }

        var deleted = await _claimHistoryService.DeleteActionHistoryAsync(claimActionHistoryId, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}