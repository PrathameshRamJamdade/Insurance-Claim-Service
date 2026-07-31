using Microsoft.AspNetCore.Mvc;

namespace Claim_ServiceAPI.Controllers;

[ApiController]
public abstract class ClaimControllerBase : ControllerBase
{
    protected ActionResult HandleInvalidOperation(InvalidOperationException exception)
    {
        return BadRequest(new ProblemDetails
        {
            Title = "Claim service validation failed.",
            Detail = exception.Message,
            Status = StatusCodes.Status400BadRequest
        });
    }
}