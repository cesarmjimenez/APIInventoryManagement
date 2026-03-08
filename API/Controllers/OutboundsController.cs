using Application.Features.OutboundsFeatures.Commands.CreateOutboundCommand;
using Application.Features.OutboundsFeatures.Commands.RecievedOutboundCommand;
using Application.Features.OutboundsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class OutboundsController(IMediator mediator) : ControllerBase
{
    [HttpPost("CreateOutbound")]
    public async Task<IActionResult> CreateOutbound([FromBody] CreateOutboundCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPost("RecievedOutbound")]
    public async Task<IActionResult> RecievedOutbound([FromBody] RecievedOutboundCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpGet("GetOutbounds")]
    public async Task<IActionResult> GetOutbounds([FromQuery] GetOutboundsQuery query)
    {
        return Ok(await mediator.Send(query));
    }
}
