using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Services.Interfaces;
using Claim_ServiceAPI.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Claim_ServiceAPI.Controllers;

[Route("api/claims/{claimId:long}/parties")]
[Authorize(Policy = ClaimServicePolicies.ClaimRead)]
public class ClaimPartiesController : ClaimControllerBase
{
    private readonly IClaimPartyService _claimPartyService;

    public ClaimPartiesController(IClaimPartyService claimPartyService)
    {
        _claimPartyService = claimPartyService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClaimPartyDto>>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken)
    {
        var parties = await _claimPartyService.GetByClaimIdAsync(claimId, cancellationToken);
        return Ok(parties);
    }

    [HttpGet("{claimPartyId:long}")]
    public async Task<ActionResult<ClaimPartyDto>> GetByIdAsync(long claimId, long claimPartyId, CancellationToken cancellationToken)
    {
        var party = await _claimPartyService.GetByIdAsync(claimPartyId, cancellationToken);
        return party == null || party.ClaimId != claimId ? NotFound() : Ok(party);
    }

    [HttpPost]
    [Authorize(Policy = ClaimServicePolicies.ClaimPartyManage)]
    public async Task<ActionResult<ClaimPartyDto>> CreateAsync(long claimId, [FromBody] CreateClaimPartyDto dto, CancellationToken cancellationToken)
    {
        if (dto.ClaimId != claimId)
        {
            return BadRequest("Route claimId and payload ClaimId must match.");
        }

        try
        {
            var party = await _claimPartyService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetByIdAsync), new { claimId, claimPartyId = party.ClaimPartyId }, party);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpPut("{claimPartyId:long}")]
    [Authorize(Policy = ClaimServicePolicies.ClaimPartyManage)]
    public async Task<ActionResult<ClaimPartyDto>> UpdateAsync(long claimId, long claimPartyId, [FromBody] UpdateClaimPartyDto dto, CancellationToken cancellationToken)
    {
        if (dto.ClaimId != claimId)
        {
            return BadRequest("Route claimId and payload ClaimId must match.");
        }

        try
        {
            var party = await _claimPartyService.UpdateAsync(claimPartyId, dto, cancellationToken);
            return party == null || party.ClaimId != claimId ? NotFound() : Ok(party);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpDelete("{claimPartyId:long}")]
    [Authorize(Policy = ClaimServicePolicies.ClaimPartyManage)]
    public async Task<IActionResult> DeleteAsync(long claimId, long claimPartyId, CancellationToken cancellationToken)
    {
        var party = await _claimPartyService.GetByIdAsync(claimPartyId, cancellationToken);
        if (party == null || party.ClaimId != claimId)
        {
            return NotFound();
        }

        var deleted = await _claimPartyService.DeleteAsync(claimPartyId, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}