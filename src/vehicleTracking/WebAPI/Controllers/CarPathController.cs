/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Application.Features.CarPaths.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPathController : CustomBaseController
    {
        #region Methods

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetAllByCarId(GetAllByCarIdCommand request)
        {
            var result = await Mediator.Send(request);
            return ActionResultInstance(result);
        }

        #endregion Methods
    }
}