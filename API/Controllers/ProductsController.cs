using Application.Features.ProductsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IMediator mediator) : Controller
{
    [HttpGet("GetActiveProducts")]
    public async Task<IActionResult> GetActiveProducts()
    {
        return Ok(await mediator.Send(new GetActiveProductsQuery()));
    }
}
