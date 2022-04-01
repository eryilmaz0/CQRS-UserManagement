using Microsoft.AspNetCore.Mvc;
using UserManagement.Command.Application.CommandModel;
using UserManagement.Command.Application.CommandResponse;
using UserManagement.Common.Mediator;

namespace UserManagement.Command.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class UserRolesController : Controller
{
   private readonly IMediatorManager _mediator;

   public UserRolesController(IMediatorManager mediator)
   {
      _mediator = mediator;
   }


   [HttpPost]
   public async Task<IActionResult> CreateUserRole([FromBody] CreateUserRoleCommand request)
   {
      var result = await _mediator.SendAsync<CreateUserRoleCommand, CreateUserRoleResponse>(request);

      if (!result.IsSuccess)
         return BadRequest(result);

      return Ok(result);
   }


   [HttpPut]
   public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleCommand request)
   {
      string lockObjectKey = $"userrole_{request.UserRoleId.ToString()}";
      var result = await _mediator.SendAsync<UpdateUserRoleCommand, UpdateUserRoleResponse>(request, lockObjectKey);
      
      if (!result.IsSuccess)
         return BadRequest(result);

      return Ok(result);
   }


   [HttpDelete]
   [Route("{userRoleId:guid}")]
   public async Task<IActionResult> RemoveUserRole(Guid userRoleId)
   {
      string lockObjectKey = $"userrole_{userRoleId.ToString()}";
      var result =
         await _mediator.SendAsync<RemoveUserRoleCommand, RemoveUserRoleResponse>(new() { UserRoleId = userRoleId }, lockObjectKey);
      
      if (!result.IsSuccess)
         return BadRequest(result);

      return Ok(result);
   }


   [HttpPost]
   [Route("AssignRole")]
   public async Task<IActionResult> AssignRole([FromBody] AssignRoleToUserCommand request)
   {
      string lockObjectKey = $"user_{request.UserId.ToString()}";
      var result = await _mediator.SendAsync<AssignRoleToUserCommand, AssignRoleToUserResponse>(request, lockObjectKey);
      
      if (!result.IsSuccess)
         return BadRequest(result);

      return Ok(result);
   }
}