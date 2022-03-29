using Microsoft.AspNetCore.Mvc;
using UserManagement.Command.Application.CommandModel;
using UserManagement.Command.Application.CommandResponse;
using UserManagement.Common.Mediator;

namespace UserManagement.Command.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class AddressesController : Controller
{
    private readonly IMediatorManager _mediator;

    public AddressesController(IMediatorManager mediator)
    {
        _mediator = mediator;
    }


    [HttpPut]
    public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommand request)
    {
        var result = await _mediator.SendAsync<UpdateAddressCommand, UpdateAddressResponse>(request);
        
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
}