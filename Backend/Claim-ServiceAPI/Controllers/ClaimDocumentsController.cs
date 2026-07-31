using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Services.Interfaces;
using Claim_ServiceAPI.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Claim_ServiceAPI.Controllers;

[Route("api/claims/{claimId:long}/documents")]
[Authorize(Policy = ClaimServicePolicies.ClaimRead)]
public class ClaimDocumentsController : ClaimControllerBase
{
    private readonly IClaimDocumentService _claimDocumentService;

    public ClaimDocumentsController(IClaimDocumentService claimDocumentService)
    {
        _claimDocumentService = claimDocumentService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClaimDocumentDto>>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken)
    {
        var documents = await _claimDocumentService.GetByClaimIdAsync(claimId, cancellationToken);
        return Ok(documents);
    }

    [HttpGet("{claimDocumentId:long}")]
    public async Task<ActionResult<ClaimDocumentDto>> GetByIdAsync(long claimId, long claimDocumentId, CancellationToken cancellationToken)
    {
        var document = await _claimDocumentService.GetByIdAsync(claimDocumentId, cancellationToken);
        return document == null || document.ClaimId != claimId ? NotFound() : Ok(document);
    }

    [HttpPost]
    [Authorize(Policy = ClaimServicePolicies.ClaimCreate)]
    public async Task<ActionResult<ClaimDocumentDto>> CreateAsync(long claimId, [FromBody] CreateClaimDocumentDto dto, CancellationToken cancellationToken)
    {
        if (dto.ClaimId != claimId)
        {
            return BadRequest("Route claimId and payload ClaimId must match.");
        }

        try
        {
            var document = await _claimDocumentService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetByIdAsync), new { claimId, claimDocumentId = document.ClaimDocumentId }, document);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpPut("{claimDocumentId:long}")]
    [Authorize(Policy = ClaimServicePolicies.ClaimUpdate)]
    public async Task<ActionResult<ClaimDocumentDto>> UpdateAsync(long claimId, long claimDocumentId, [FromBody] UpdateClaimDocumentDto dto, CancellationToken cancellationToken)
    {
        if (dto.ClaimId != claimId)
        {
            return BadRequest("Route claimId and payload ClaimId must match.");
        }

        try
        {
            var document = await _claimDocumentService.UpdateAsync(claimDocumentId, dto, cancellationToken);
            return document == null || document.ClaimId != claimId ? NotFound() : Ok(document);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpDelete("{claimDocumentId:long}")]
    [Authorize(Policy = ClaimServicePolicies.ClaimUpdate)]
    public async Task<IActionResult> DeleteAsync(long claimId, long claimDocumentId, CancellationToken cancellationToken)
    {
        var document = await _claimDocumentService.GetByIdAsync(claimDocumentId, cancellationToken);
        if (document == null || document.ClaimId != claimId)
        {
            return NotFound();
        }

        var deleted = await _claimDocumentService.DeleteAsync(claimDocumentId, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}