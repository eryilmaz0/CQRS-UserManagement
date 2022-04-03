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
   public async Task<IActionResult> GetUserWithDetail([FromBody] GetUserWithDetailQuery request)
   {
      var result = await _mediator.SendAsync<GetUserWithDetailQuery, GetUserWithDetailQueryResponse>(request);

      if (!result.IsSuccess)
         return BadRequest(result);

      return Ok(result);
   }



   [HttpGet]
   public async Task<IActionResult> GetUserWithRoles([FromBody] GetUserWithRolesQuery request)
   {
      var result = await _mediator.SendAsync<GetUserWithRolesQuery, GetUserWithRolesQueryResponse>(request);

      if (!result.IsSuccess)
         return BadRequest(result);

      return Ok(result);
   }
   
}