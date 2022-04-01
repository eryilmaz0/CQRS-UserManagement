using Microsoft.AspNetCore.Mvc;
using UserManagement.Command.Application.CommandModel;
using UserManagement.Command.Application.CommandResponse;
using UserManagement.Common.Mediator;

namespace UserManagement.Command.API.Controllers;

[ApiController]
[Route("api/[Controller]/")]
public class UsersController : Controller
{
    private readonly IMediatorManager _mediator;

    public UsersController(IMediatorManager mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request)
    {
        var result = await _mediator.SendAsync<CreateUserCommand, CreateUserResponse>(request);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }


    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand request)
    {
        string lockObjectKey = $"user_{request.UserId.ToString()}";
        var result = await _mediator.SendAsync<UpdateUserCommand, UpdateUserResponse>(request, lockObjectKey);
        
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }


    [HttpDelete]
    [Route("{userId}")]
    public async Task<IActionResult> RemoveUser([FromRoute] Guid userId)
    {
        string lockObjectKey = $"user_{userId.ToString()}";
        var result = 
            await _mediator.SendAsync<RemoveUserCommand, RemoveUserResponse>(new() { UserId = userId } , lockObjectKey );
        
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }


    [HttpPost]
    [Route("ConfirmUser")]
    public async Task<IActionResult> ConfirmUser([FromBody] ConfirmUserCommand request)
    {
        string lockObjectKey = $"user_{request.UserId.ToString()}";
        var result = await _mediator.SendAsync<ConfirmUserCommand, ConfirmUserResponse>(request, lockObjectKey);
        
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
    
}