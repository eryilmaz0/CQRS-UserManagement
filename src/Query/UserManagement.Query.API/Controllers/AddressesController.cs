using Microsoft.AspNetCore.Mvc;
using UserManagement.Common.Mediator;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.QueryResponse;

namespace UserManagement.Query.API.Controllers;


[ApiController]
[Route("api/[Controller]/[Action]")]
public class AddressesController : ControllerBase
{
    private readonly IMediatorManager _mediator;

    public AddressesController(IMediatorManager mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("{userId}")]
    public async Task<IActionResult> GetUserAddress([FromRoute] Guid userId)
    {
        var result = await _mediator.SendAsync<GetUserAddressQuery, GetUserAddressQueryResponse>(new(){UserId = userId});

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
}