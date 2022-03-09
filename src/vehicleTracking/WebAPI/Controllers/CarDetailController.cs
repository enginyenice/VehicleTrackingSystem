using Application.Features.CarDetails.Commands;
using Application.Features.CarDetails.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDetailController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCarDetail(CreateCarDetailCommand createCarDetailCommand)
        {
            var result = await Mediator.Send(createCarDetailCommand);
            return ActionResultInstance(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarDetail()
        {
            var result = await Mediator.Send(new GetAllCarDetailCommand());
            return ActionResultInstance(result);
        }
    }
}