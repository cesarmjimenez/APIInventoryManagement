using Application.Features.OutboundsFeatures.Commands.CreateOutboundCommand;
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
}
