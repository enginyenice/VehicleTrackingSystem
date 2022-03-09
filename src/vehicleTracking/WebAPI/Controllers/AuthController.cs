using Application.Features.Authentications.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        [SwaggerOperation(Summary = "Login Endpoint", Description = "Example Account: username: userone password: password ")]
        [HttpPost]
        public async Task<IActionResult> Login(CheckAuthenticationCommand checkAuthenticationCommand)
        {
            var response = await Mediator.Send(checkAuthenticationCommand);
            return ActionResultInstance(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Test()
        {
            return Ok("Ok");
        }
    }
}