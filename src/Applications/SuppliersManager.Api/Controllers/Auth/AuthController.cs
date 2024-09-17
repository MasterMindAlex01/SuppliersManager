using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuppliersManager.Application.Features.Auth.Commands;

namespace SuppliersManager.Api.Controllers
{
    public class AuthController : BaseApiController<AuthController>
    {        
        // POST api/Auth
        [HttpPost]
        public async Task<IActionResult> Post(TokenCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {

            var data = HttpContext.User.Claims.Select(x => new
            {
                x.Value,
                x.Type
            });

            return Ok(new
            {
                data
            });
        }
    }
}
