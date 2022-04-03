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
    public async Task<IActionResult> GetUserAddress([FromBody] GetUserAddressQuery request)
    {
        var result = await _mediator.SendAsync<GetUserAddressQuery, GetUserAddressQueryResponse>(request);

        if (!result.IsSuccess)
            return BadRequest(request);

        return Ok(result);
    }
}