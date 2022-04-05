using Microsoft.AspNetCore.Mvc;
using UserManagement.Common.Mediator;
using UserManagement.Query.Domain.Entity;
using UserManager.Query.Application.QueryModel;
using UserManager.Query.Application.QueryResponse;

namespace UserManagement.Query.API.Controllers;


[ApiController]
[Route("api/[Controller]/[Action]")]
public class UserRolesController : ControllerBase
{
   private readonly IMediatorManager _mediator;

   public UserRolesController(IMediatorManager mediator)
   {
      _mediator = mediator;
   }


   [HttpGet]
   public async Task<IActionResult> ListRoles([FromBody] ListRolesQuery request)
   {
      var result = await _mediator.SendAsync<ListRolesQuery, ListRolesQueryResponse>(request);

      if (!result.IsSuccess)
         return BadRequest(result);

      return Ok(result);
   }
}