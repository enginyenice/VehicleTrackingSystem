/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Features.Authentications.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        #region Methods

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

        #endregion Methods
    }
}