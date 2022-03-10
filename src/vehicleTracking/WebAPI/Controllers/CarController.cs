using Application.Features.Cars.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : CustomBaseController
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllByUserId()
        {
            GetAllByUserIdCommand result = new GetAllByUserIdCommand() { UserId = NameIdentifier };
            var response = await Mediator.Send(result);
            return ActionResultInstance(response);
        }
    }
}