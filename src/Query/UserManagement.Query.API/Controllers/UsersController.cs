using Microsoft.AspNetCore.Mvc;
using UserManagement.Common.Mediator;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.QueryResponse;

namespace UserManagement.Query.API.Controllers;

[ApiController]
[Route("api/[Controller]/[Action]")]
public class UsersController : ControllerBase
{
   private readonly IMediatorManager _mediator;

   public UsersController(IMediatorManager mediator)
   {
      _mediator = mediator;
   }

   
   [HttpGet]
   public async Task<IActionResult> ListUsers()
   {
      var result = await _mediator.SendAsync<ListUsersQuery, ListUsersQueryResponse>(new());

      if (!result.IsSuccess)
         return BadRequest(result);

      return Ok(result);
   }


   [HttpGet]
   [Route("{userId}")]
   public async Task<IActionResult> GetUserWithDetail([FromRoute] Guid userId)
   {
      var result = await _mediator.SendAsync<GetUserWithDetailQuery, GetUserWithDetailQueryResponse>(new(){UserId = userId});

      if (!result.IsSuccess)
         return BadRequest(result);

      return Ok(result);
   }



   [HttpGet]
   [Route("{userId}")]
   public async Task<IActionResult> GetUserWithRoles([FromRoute] Guid userId)
   {
      var result = await _mediator.SendAsync<GetUserWithRolesQuery, GetUserWithRolesQueryResponse>(new(){UserId = userId});

      if (!result.IsSuccess)
         return BadRequest(result);

      return Ok(result);
   }
   
}