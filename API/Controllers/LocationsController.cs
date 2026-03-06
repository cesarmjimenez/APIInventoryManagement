using Application.Features.LocationsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController(IMediator mediator) : ControllerBase
{
    [HttpGet("GetBranches")]
    public async Task<IActionResult> GetBranches()
    {
        return Ok(await mediator.Send(new GetDestinationQuery()));
    }
}
