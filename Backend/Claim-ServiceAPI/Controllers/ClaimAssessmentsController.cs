using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Services.Interfaces;
using Claim_ServiceAPI.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Claim_ServiceAPI.Controllers;

[Route("api/claims/{claimId:long}/assessments")]
[Authorize(Policy = ClaimServicePolicies.ClaimRead)]
public class ClaimAssessmentsController : ClaimControllerBase
{
    private readonly IClaimAssessmentService _claimAssessmentService;

    public ClaimAssessmentsController(IClaimAssessmentService claimAssessmentService)
    {
        _claimAssessmentService = claimAssessmentService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClaimAssessmentDto>>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken)
    {
        var assessments = await _claimAssessmentService.GetByClaimIdAsync(claimId, cancellationToken);
        return Ok(assessments);
    }

    [HttpGet("{claimAssessmentId:long}")]
    public async Task<ActionResult<ClaimAssessmentDto>> GetByIdAsync(long claimId, long claimAssessmentId, CancellationToken cancellationToken)
    {
        var assessment = await _claimAssessmentService.GetByIdAsync(claimAssessmentId, cancellationToken);
        return assessment == null || assessment.ClaimId != claimId ? NotFound() : Ok(assessment);
    }

    [HttpPost]
    [Authorize(Policy = ClaimServicePolicies.ClaimAssessmentManage)]
    public async Task<ActionResult<ClaimAssessmentDto>> CreateAsync(long claimId, [FromBody] CreateClaimAssessmentDto dto, CancellationToken cancellationToken)
    {
        if (dto.ClaimId != claimId)
        {
            return BadRequest("Route claimId and payload ClaimId must match.");
        }

        try
        {
            var assessment = await _claimAssessmentService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetByIdAsync), new { claimId, claimAssessmentId = assessment.ClaimAssessmentId }, assessment);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpPut("{claimAssessmentId:long}")]
    [Authorize(Policy = ClaimServicePolicies.ClaimAssessmentManage)]
    public async Task<ActionResult<ClaimAssessmentDto>> UpdateAsync(long claimId, long claimAssessmentId, [FromBody] UpdateClaimAssessmentDto dto, CancellationToken cancellationToken)
    {
        if (dto.ClaimId != claimId)
        {
            return BadRequest("Route claimId and payload ClaimId must match.");
        }

        try
        {
            var assessment = await _claimAssessmentService.UpdateAsync(claimAssessmentId, dto, cancellationToken);
            return assessment == null || assessment.ClaimId != claimId ? NotFound() : Ok(assessment);
        }
        catch (InvalidOperationException exception)
        {
            return HandleInvalidOperation(exception);
        }
    }

    [HttpDelete("{claimAssessmentId:long}")]
    [Authorize(Policy = ClaimServicePolicies.ClaimAssessmentManage)]
    public async Task<IActionResult> DeleteAsync(long claimId, long claimAssessmentId, CancellationToken cancellationToken)
    {
        var assessment = await _claimAssessmentService.GetByIdAsync(claimAssessmentId, cancellationToken);
        if (assessment == null || assessment.ClaimId != claimId)
        {
            return NotFound();
        }

        var deleted = await _claimAssessmentService.DeleteAsync(claimAssessmentId, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}