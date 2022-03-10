/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Features.Cars.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : CustomBaseController
    {
        #region Methods

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllByUserId()
        {
            GetAllByUserIdCommand result = new GetAllByUserIdCommand() { UserId = NameIdentifier };
            var response = await Mediator.Send(result);
            return ActionResultInstance(response);
        }

        #endregion Methods
    }
}